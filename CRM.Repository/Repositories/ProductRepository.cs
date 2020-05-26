using CRM.Core;
using CRM.DB.Models;
using CRM.DB.Storages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Repository.Common;

namespace CRM.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IProductStorage _productStorage;

        public ProductRepository(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public async ValueTask<RequestResult<List<MostlySaleProduct>>> GetMostlySalesProduct()
        {
            var result = new RequestResult<List<MostlySaleProduct>>();
            try
            {
                result.RequestData = await _productStorage.GetBestSellingProductByCity();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductWithCategoryReport(ReportTypeEnum reportType)
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _productStorage.GetProductWithCategoryReport(reportType);
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<СategoryProduct>>> CategoriesMoreFiveProducts(ReportTypeEnum reportType)
        {
            var result = new RequestResult<List<СategoryProduct>>();
            try
            {
                result.RequestData = await _productStorage.CategoriesMoreFiveProducts(reportType);
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
