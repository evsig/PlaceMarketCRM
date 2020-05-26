using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<List<OrdersByDatesOutputModel>>> GetSumSalesBetweenDates(ByDatesInputModel inputModel);
        ValueTask<ActionResult<List<CashInStoreOutputModel>>> GetCashInPoint();
        ValueTask<ActionResult<SalesByIsForeignOutputModel>> GetCashInAbroad();
    }
}