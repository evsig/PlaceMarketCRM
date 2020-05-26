using CRM.Core;
using CRM.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Repository.Common;

namespace CRM.Repository.Repositories
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<List<MostlySaleProduct>>> GetMostlySalesProduct();
        ValueTask<RequestResult<List<Product>>> GetProductWithCategoryReport(ReportTypeEnum reportType);
        ValueTask<RequestResult<List<СategoryProduct>>> CategoriesMoreFiveProducts(ReportTypeEnum reportType);
    }
}