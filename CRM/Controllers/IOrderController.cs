using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.API.Models.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<OrderOutputModel>> AddOrder(OrderInputModel inputModel);
        ValueTask<ActionResult<OrderOutputModel>> GetOrderWithDetails(int id);

    }
}