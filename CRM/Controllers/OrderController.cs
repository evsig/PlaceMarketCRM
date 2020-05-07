using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.API.Models.InputModels;
using CRM.DB.Models;
using AutoMapper;
using CRM.API.Models.OutputModels;
using CRM.Repository;
using CRM.Core;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderController (IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async ValueTask<ActionResult<OrderOutputModel>> AddOrder(OrderInputModel inputModel)
        {
            var result = await _orderRepository.AddOrder(_mapper.Map<Order>(inputModel));
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Request data is not exist");
                return Ok(_mapper.Map<OrderOutputModel>(result.RequestData));
            }
            return Problem(result.ExMessage, statusCode: 520);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<OrderOutputModel>> GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderById(id);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Request data is not exist");
                return Ok(_mapper.Map<OrderOutputModel>(result.RequestData));
            }
            return Problem(result.ExMessage, statusCode: 520);
        }

        [HttpGet("date")]
        public async ValueTask<ActionResult<List<OrderOutputModel>>> GetOrderByDate(PeriodInputModel inputModel)
        {
            DateTime startDate = Convert.ToDateTime(inputModel.StartDate);
            DateTime endDate = Convert.ToDateTime(inputModel.EndDate);

            var result = await _orderRepository.GetOrderByDate(startDate, endDate);
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Request data is not exist");
                return Ok(_mapper.Map<List<OrderOutputModel>>(result.RequestData));
            }
            return Problem(result.ExMessage, statusCode: 520);
        }

        [HttpGet("cash-in-points")]
        public async ValueTask<ActionResult<List<CashPointOutputModel>>> GetCashInPoint()
        {
            var result = await _orderRepository.GetCashInPoint();
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Request data is not exist");
                return Ok(_mapper.Map<List<CashPointOutputModel>>(result.RequestData));
            }
            return Problem(result.ExMessage, statusCode: 520);
        }

        [HttpGet("cash-in-abroad")]
        public async ValueTask<ActionResult<CashPointOutputModel>> GetCashInAbroad()
        {
            var result = await _orderRepository.GetCashInAbroad();
            if (result.IsOk)
            {
                if (result.RequestData == null) return NotFound("Request data is not exist");
                return Ok(_mapper.Map<CashPointOutputModel>(result.RequestData));
            }
            return Problem(result.ExMessage, statusCode: 520);
        }

    }
}
