using Dapper;
using CRM.Core;
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
    public class ProductStorage : IProductStorage
    {

        private IDbConnection connection;

        public ProductStorage(IOptions<StorageOptions> storageOptions)
        {
            this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        private static class SpName
        {
            public const string CategoriesMoreFiveProducts = "CategoriesMoreFiveProducts";
            public const string ProductMostlySales = "Product_MostlySales";
            public const string ProductNeverSale = "Product_NeverSale";
            public const string ProductOnlyInStorage = "Product_OnlyInStorage";
            public const string ProductOver = "Product_Over";
        }

        public async ValueTask<List<MostlySaleProduct>> GetBestSellingProductByCity()
        {
            try
            {
                var result = await connection.QueryAsync<MostlySaleProduct, int, MostlySaleProduct>(
                    SpName.ProductMostlySales,
                   (w, g) =>
                   {
                       MostlySaleProduct store = w;
                       store.ProductId = g;
                       return store;
                   },
                    param: null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "ProductId");
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetProductWithCategoryReport(ReportTypeEnum reportType)
        {
            string proc = "";
            switch (reportType)
            {
                case ReportTypeEnum.GetProductNeverSale:
                    proc = SpName.ProductNeverSale;
                    break;
                case ReportTypeEnum.GetProductOver:
                    proc = SpName.ProductOver;
                    break;
                case ReportTypeEnum.GetProductOnlyInStorage:
                    proc = SpName.ProductOnlyInStorage;
                    break;
            }

            try
            {
                var result = await connection.QueryAsync<Category, Product, Product>(
                    proc,
                    (c, p) =>
                    {
                        Product product = p;
                        product.Category = c;
                        return product;
                    },
                    param: null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<СategoryProduct>> CategoriesMoreFiveProducts(ReportTypeEnum reportType)
        {
            try
            {
                var result = await connection.QueryAsync<СategoryProduct, int, СategoryProduct>(
                    SpName.CategoriesMoreFiveProducts,
                    (c, p) =>
                    {
                        СategoryProduct category = c;
                        category.CountProducts = p;
                        return category;
                    },
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}
