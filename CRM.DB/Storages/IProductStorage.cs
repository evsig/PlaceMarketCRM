using CRM.Core;
using CRM.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<Product> GetProductById(int id);
        ValueTask<List<PointMostlySalesProduct>> GetProductsMostlySales();
        ValueTask<List<CategoryCountProducts>> GetCategoriesMoreFiveProducts();
        ValueTask<Product> GetProductsWithCategory(ReportEnum reportType);
    }
}
