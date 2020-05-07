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
            public const string OrderAdd = "Order_Add";
            public const string OrderDetailsAdd = "OrderDetails_Add";
            public const string GetOrderById = "Order_SelectById";

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
                    commandType: CommandType.StoredProcedure);

                model.Id = OrderID.FirstOrDefault();

                await AddOrderDetails(model.OrderDetails, (int)model.Id);
                return await GetOrderById((int)model.Id);
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
                    int? ProductId = orderDetails.Product.Id;
                    DynamicParameters parameters = new DynamicParameters(new
                    {
                        orderId,
                        ProductId,
                        orderDetails.Count,
                        orderDetails.Price
                    });

                    await connection.QueryAsync<int>(
                    SpName.OrderDetailsAdd,
                    parameters,
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Order> GetOrderById(int Id)
        {
            try
            {
                var orderDictionary = new Dictionary<int, Order>();
                var result = await connection.QueryAsync<Order, Point, OrderDetails, Product, Category, Order>(
                    SpName.GetOrderById,
                    (order, point, orderDetails, product, category) =>
                    {
                        Order orderEntry;
                        if (!orderDictionary.TryGetValue((int)order.Id, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderDetails = new List<OrderDetails>();
                            orderDictionary.Add((int)orderEntry.Id, orderEntry);
                        }
                        orderEntry.Point = point;
                        orderEntry.OrderDetails.Add(orderDetails);
                        orderDetails.Product = product;
                        product.Category = category;
                        return orderEntry;
                    },
                    param: new { Id },
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.FirstOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

    }
}
