using CRM.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<Product>> GetProductsMostlySales();
        ValueTask<List<Product>> GetProductsNeverSale();
        ValueTask<List<Product>> GetProductsOnlyInStorage();
        ValueTask<List<Product>> GetProductsOver();
        ValueTask<List<PointWithCash>> GetSelectCashInEachPoint();
        ValueTask<List<Category>> GetCategoriesMoreFiveProducts();
        ValueTask<List<PointWithCash>> GetSumSalesBetweenDates();
        ValueTask<List<PointWithCash>> GetSumSalesInEachPoint();
        ValueTask<List<Cash>> GetSumSalesInRussiaAndAbroad();
    }
}
