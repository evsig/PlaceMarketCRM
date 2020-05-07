using CRM.Core;
using CRM.DB.Models;
using CRM.DB.Storages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IProductStorage _productStorage;

        public ProductRepository(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public async ValueTask<RequestResult<List<PointMostlySalesProduct>>> GetMostlySellingProduct()
        {
            var result = new RequestResult<List<PointMostlySalesProduct>>();
            try
            {
                result.RequestData = await _productStorage.GetMostlySellingProduct();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductsWithCategory(ReportEnum reportType)
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _productStorage.GetProductsWithCategory();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<CategoryCountProducts>>> GetСategoriesMoreThenXProducts(int amount)
        {
            var result = new RequestResult<List<CategoryCountProducts>>();
            try
            {
                result.RequestData = await _productStorage.GetСategoriesMoreThenXProducts();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
