using CRM.Core;
using CRM.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<List<PointMostlySalesProduct>>> GetMostlySellingProduct();
        ValueTask<RequestResult<List<CategoryCountProducts>>> GetСategoriesMoreThenXProducts(int amount);
        ValueTask<RequestResult<List<Product>>> GetProductsWithCategory(ReportEnum reportType);
    }
}
