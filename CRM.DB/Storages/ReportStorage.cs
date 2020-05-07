using Dapper;
using CRM.DB.Models;
using CRM.Core.ConfigurationOptions;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public class ReportStorage : IReportStorage
    {
        private IDbConnection _connection;
        public ReportStorage(IOptions<StorageOptions> storageOptions)
        {
            _connection = new SqlConnection(storageOptions.Value.DBConnectionString);
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

        public async ValueTask<List<Product>> GetProductsMostlySales()
        {
            try
            {
                var result = await _connection.QueryAsync<Product, Category, Category, Product>(
                            SpName.GetProductsMostlySales,
                            (product, category, parentCategory) =>
                            {
                                Product newProduct = product;
                                Category newCategory = category;
                                newProduct.Category = newCategory;
                                return newProduct;
                            },
                            null,
                            commandType: CommandType.StoredProcedure,
                            splitOn: "Id, Id, Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }        
        
        public async ValueTask<List<Product>> GetProductsNeverSale()
        {
            try
            {
                var result = await _connection.QueryAsync<Product, Category, Category, Product>(
                            SpName.GetProductsNeverSale,
                            (product, category, parentCategory) =>
                            {
                                Product newProduct = product;
                                Category newCategory = category;
                                newProduct.Category = newCategory;
                                return newProduct;
                            },
                            null,
                            commandType: CommandType.StoredProcedure,
                            splitOn: "Id, Id, Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }        
        
        public async ValueTask<List<Product>> GetProductsOnlyInStorage()
        {
            try
            {
                var result = await _connection.QueryAsync<Product, Category, Category, Product>(
                            SpName.GetProductsOnlyInStorage,
                            (product, category, parentCategory) =>
                            {
                                Product newProduct = product;
                                Category newCategory = category;
                                newProduct.Category = newCategory;
                                return newProduct;
                            },
                            null,
                            commandType: CommandType.StoredProcedure,
                            splitOn: "Id, Id, Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }        
        
        public async ValueTask<List<Product>> GetProductsOver()
        {
            try
            {
                var result = await _connection.QueryAsync<Product, Category, Category, Product>(
                            SpName.GetProductsOver,
                            (product, category, parentCategory) =>
                            {
                                Product newProduct = product;
                                Category newCategory = category;
                                newProduct.Category = newCategory;
                                return newProduct;
                            },
                            null,
                            commandType: CommandType.StoredProcedure,
                            splitOn: "Id, Id, Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public async ValueTask<List<Category>> GetCategoriesMoreFiveProducts()
        {
            try
            {
                var result = await _connection.QueryAsync<Product, Category, Category>(
                            SpName.GetCategoriesMoreFiveProducts,
                            (product, category) =>
                            {
                                Product newProduct = product;
                                Category newCategory = category;
                                newProduct.Category = newCategory;
                                return newCategory;
                            },
                            null,
                            commandType: CommandType.StoredProcedure,
                            splitOn: "Id, Id, Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<PointWithCash>> GetSelectCashInEachPoint()
        {
            try
            {
                var result = await _connection.QueryAsync<PointWithCash>(
                            SpName.GetSelectCashInEachPoint,
                            null,
                            commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<PointWithCash>> GetSumSalesBetweenDates(Period date)
        {
            try
            {
                DynamicParameters periodModelParams = new DynamicParameters(new { date.StartDate, date.EndDate });
                var result = await _connection.QueryAsync<PointWithCash>(
                                SpName.GetSumSalesBetweenDates,
                                periodModelParams,
                                commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<PointWithCash>> GetSumSalesInEachPoint()
        {
            try
            {
                var result = await _connection.QueryAsync<PointWithCash>(
                           SpName.GetSumSalesInEachPoint,
                           null,
                           commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Cash>> GetSumSalesInRussiaAndAbroad()
        {
            try
            {
                var result = await _connection.QueryAsync<Cash>(
                           SpName.GetSumSalesInRussiaAndAbroad,
                           null,
                           commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
