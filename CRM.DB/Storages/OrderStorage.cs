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
            if (this.connection == null) { 
                connection = new SqlConnection("Data Source = (local); Initial Catalog = Store; Integrated Security=True;");
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

        private static class SpName
        {
            public const string SumSalesBetweenDates = "SumSalesBetweenDates";
            public const string ProductCashInPoint = "Product_CashInPoint";
            public const string SalesInSomeCountry = "SalesInSomeCountry";
        }

        public async ValueTask<List<CashInPoint>> GetCashInPoint()
        {
            try
            {
                var result = await connection.QueryAsync<decimal, CashInPoint, CashInPoint>(
                    SpName.ProductCashInPoint,
                    (t, w) =>
                    {
                        CashInPoint store = w;
                        store.TotalMoney = t;
                        return store;
                    },
                    param: null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
        public async ValueTask<List<OrdersByDates>> GetSumSalesBetweenDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await connection.QueryAsync<OrdersByDates, Store, Product, Category, int, decimal, OrdersByDates>(
                    SpName.SumSalesBetweenDates,
                    (o, s, p, c, co, ca) =>
                    {
                        OrdersByDates order = o;
                        o.Store = s;
                        o.Count = co;
                        o.Cash = ca;
                        o.Product = p;
                        p.Category = c;
                        return order;
                    },
                    param: new { FromDate = startDate, ToDate = endDate },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id,Id,Id,Count,Cash");
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
                    SpName.SalesInSomeCountry,
                    param: null,
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}
