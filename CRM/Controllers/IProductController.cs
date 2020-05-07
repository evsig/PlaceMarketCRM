using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    public interface IProductController
    {
        ValueTask<ActionResult<List<MostlySalesProductOutputModel>>> GetMostlySalesProduct();
        ValueTask<ActionResult<List<ProductsCountInCategoryOutputModel>>> GetCategoriesMoreFiveProducts();
        ValueTask<ActionResult<List<ProductsWithCategoryOutputModel>>> GetProductsNeverSale();
        ValueTask<ActionResult<List<ProductsWithCategoryOutputModel>>> GetProductsOver();
        ValueTask<ActionResult<List<ProductsWithCategoryOutputModel>>> GetProductsOnlyInStorage();
    }
}
