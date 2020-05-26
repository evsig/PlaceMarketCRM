using CRM.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Repository.Common;

namespace CRM.Repository.Repositories
{
    public interface IOrderRepository
    {     
        ValueTask<RequestResult<List<CashInPoint>>> GetCashInPoint();
        ValueTask<RequestResult<List<OrdersByDates>>> GetOrdersByDates(DateTime startDate, DateTime endDate);
        ValueTask<RequestResult<Order>> GetCashInAbroad();
    }
}