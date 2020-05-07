using Dapper;
using CRM.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CRM.Core.ConfigurationOptions;

namespace CRM.DB.Storages
{
    public class OrderStorage : IOrderStorage
    {

        private IDbConnection connection;
        private IDbTransaction transaction;

        public OrderStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }
        public void TransactionStart()
        {
            if (this.connection == null)
            {
                connection = new SqlConnection("Data Source = (local); Initial Catalog = CRM; Integrated Security=True;");
            }

            connection.Open();
            transaction = this.connection.BeginTransaction();
        }
        public void TransactionCommit()
        {
            this.transaction?.Commit();
            connection?.Close();
        }
        public void TransactionRollBack()
        {
            this.transaction?.Rollback();
            connection?.Close();
        }

        internal static class SpName
        {
            public const string GetProductsMostlySales = "GetProductsMostlySales";
            public const string GetProductsNeverSale = "GetProductsNeverSale";
            public const string GetProductsOnlyInStorage = "GetProductsOnlyInStorage";
            public const string GetProductsOver = "GetProductsOver";
            public const string GetCategoriesMoreFiveProducts = "GetCategoriesMoreFiveProducts";
            public const string GetSelectCashInEachPoint = "GetSelectCashInEachPoint";
            public const string GetSumSalesBetweenDates = "GetSumSalesBetweenDates";
            public const string GetSumSalesInEachPoint = "GetSumSalesInEachPoint";
            public const string GetSumSalesInRussiaAndAbroad = "GetSumSalesInRussiaAndAbroad";

        }

        public async ValueTask<Order> AddOrder(Order model)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters(new
                {
                    PointId = model.Point.Id
                });

                var OrderID = await connection.QueryAsync<int>(
                    SpName.OrderAdd,
                    parameters,
                    transaction: transaction,
                    commandType: CommandType.CRMdProcedure);

                model.Id = OrderID.FirstOrDefault();

                await AddOrderDetails(model.OrderDetails, (int)model.Id);
                return await GetOrderWithDetailsById((int)model.Id);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask AddOrderDetails(List<OrderDetails> models, int orderId)
        {
            try
            {
                foreach (OrderDetails orderDetails in models)
                {
                    int ProductId = orderDetails.Product.Id;
                    DynamicParameters parameters = new DynamicParameters(new
                    {
                        orderId,
                        ProductId,
                        orderDetails.Quantity,
                        orderDetails.LocalPrice
                    });

                    await connection.QueryAsync<int>(
                    SpName.OrderDetailsAdd,
                    parameters,
                    transaction: transaction,
                    commandType: CommandType.CRMdProcedure);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Order> GetOrderWithDetailsById(int Id)
        {
            try
            {
                var orderDictionary = new Dictionary<int, Order>();
                var result = await connection.QueryAsync<Order, Point, OrderDetails, Product, Category, Order>(
                    SpName.OrderWithDetailsSelectById,
                    (o, w, od, g, c) =>
                    {
                        Order orderEntry;
                        if (!orderDictionary.TryGetValue((int)o.Id, out orderEntry))
                        {
                            orderEntry = o;
                            orderEntry.OrderDetails = new List<OrderDetails>();
                            orderDictionary.Add((int)orderEntry.Id, orderEntry);
                        }
                        orderEntry.Point = w;
                        orderEntry.OrderDetails.Add(od);
                        od.Product = g;
                        g.Category = c;
                        return orderEntry;
                    },
                    param: new { Id },
                    transaction: transaction,
                    commandType: CommandType.CRMdProcedure,
                    splitOn: "Id");
                return result.FirstOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<PointTotalCost>> GetTotalCostByPoint()
        {
            try
            {
                var result = await connection.QueryAsync<decimal, PointTotalCost, PointTotalCost>(
                    SpName.ProductTotalCostByPoint,
                    (t, w) =>
                    {
                        PointTotalCost Point = w;
                        Point.TotalMoney = t;
                        return Point;
                    },
                    param: null,
                    commandType: CommandType.CRMdProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
        public async ValueTask<List<OrdersByDates>> GetOrdersByDates(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await connection.QueryAsync<OrdersByDates, Point, Product, Category, int, decimal, OrdersByDates>(
                    SpName.OrderByDates,
                    (o, w, g, c, tq, tc) =>
                    {
                        OrdersByDates order = o;
                        o.Point = w;
                        o.TotalQuantity = tq;
                        o.TotalCost = tc;
                        o.Product = g;
                        g.Category = c;
                        return order;
                    },
                    param: new { FromDate, ToDate },
                    commandType: CommandType.CRMdProcedure,
                    splitOn: "Id,Id,Id,TotalQuantity,TotalCost");
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Order> GetTotalCostByIsForeign()
        {
            try
            {
                var result = await connection.QueryAsync<Order>(
                    SpName.TotalSumByIsForeign,
                    param: null,
                    commandType: CommandType.CRMdProcedure);
                return result.FirstOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}
