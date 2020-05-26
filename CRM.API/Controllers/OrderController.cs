using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.DB.Models;
using AutoMapper;
using CRM.API.Models.OutputModels;
using CRM.Repository.Repositories;
using CRM.Core;

namespace CRM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
/*
        private IOrderController _orderControllerImplementation;
*/

        public OrderController(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        [HttpGet("by-dates")] 
        public async ValueTask<ActionResult<List<OrdersByDatesOutputModel>>> GetSumSalesBetweenDates(ByDatesInputModel inputModel)
        {
            DateTime fromDate = Convert.ToDateTime(inputModel.FromDate);
            DateTime toDate = Convert.ToDateTime(inputModel.ToDate);

            var result = await _orderRepository.GetOrdersByDates(fromDate, toDate);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Orders not found");
                return Ok(_mapper.Map<List<OrdersByDatesOutputModel>>(result.RequestData));
            }
            return Problem($"Getting orders failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("by-point")]
        public async ValueTask<ActionResult<List<CashInStoreOutputModel>>> GetCashInPoint()
        {
            var result = await _orderRepository.GetCashInPoint();
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Something went wrong");
                return Ok(_mapper.Map<List<CashInStoreOutputModel>>(result.RequestData));
            }
            return Problem($"Getting total cost failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("by-abroad")]
        public async ValueTask<ActionResult<SalesByIsForeignOutputModel>> GetCashInAbroad()
        {
            var result = await _orderRepository.GetCashInAbroad();
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Something went wrong");
                return Ok(_mapper.Map<SalesByIsForeignOutputModel>(result.RequestData));
            }
            return Problem($"Getting total cost failed {result.ExMessage}", statusCode: 520);
        }
    }
}
