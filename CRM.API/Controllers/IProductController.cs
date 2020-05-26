using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    public interface IProductController
    {
        ValueTask<ActionResult<List<MostlySalesProductOutputModel>>> GetMostlySalesProduct();
        ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetСategoriesMoreFiveProducts();
        ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductNeverSale();
        ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductOver();
        ValueTask<ActionResult<List<ProductWithCategoryOutputModel>>> GetProductOnlyInStorage();
    }
}