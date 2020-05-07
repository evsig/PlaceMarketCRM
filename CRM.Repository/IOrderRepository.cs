using CRM.DB.Models;
using System;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IOrderRepository
    {
        ValueTask<RequestResult<Order>> AddOrder(Order dataModel);
        ValueTask<RequestResult<Order>> GetOrderById(int id);
        ValueTask<RequestResult<Order>> GetOrderByDate(DateTime startDate, DateTime endDate);
        ValueTask<RequestResult<Order>> GetCashInPoint();
        ValueTask<RequestResult<Order>> GetCashInAbroad();
    }
}
