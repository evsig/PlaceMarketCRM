using CRM.Core;
using CRM.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<List<MostlySaleProduct>> GetBestSellingProductByCity();
        ValueTask<List<Product>> GetProductWithCategoryReport(ReportTypeEnum reportType);
        ValueTask<List<СategoryProduct>> CategoriesMoreFiveProducts(ReportTypeEnum reportType);
    }
}