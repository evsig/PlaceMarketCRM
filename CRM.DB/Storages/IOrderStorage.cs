using CRM.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<List<CashInPoint>> GetCashInPoint();
        ValueTask<List<OrdersByDates>> GetSumSalesBetweenDates(DateTime startDate, DateTime endDate);
        ValueTask<Order> GetTotalCostByIsForeign();
        void TransactionCommit();
        void TransactionStart();
        void TransactionRollBack();
    }
}