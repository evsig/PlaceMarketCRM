using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Core;
using CRM.DB.Models;
using CRM.DB.Storages;
using CRM.Repository.Common;

namespace CRM.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IOrderStorage _orderStorage;

        public OrderRepository(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }



        public async ValueTask<RequestResult<List<CashInPoint>>> GetCashInPoint()
        {
            var result = new RequestResult<List<CashInPoint>>();
            try
            {
                result.RequestData = await _orderStorage.GetCashInPoint();

                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
        public async ValueTask<RequestResult<List<OrdersByDates>>> GetOrdersByDates(DateTime startDate, DateTime endDate)
        {
            var result = new RequestResult<List<OrdersByDates>>();
            try
            {
                result.RequestData = await _orderStorage.GetSumSalesBetweenDates(startDate, endDate);

                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<Order>> GetCashInAbroad()
        {
            var result = new RequestResult<Order>();
            try
            {
                result.RequestData = await _orderStorage.GetTotalCostByIsForeign();

                result.IsOk = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
