using CRM.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<Order> AddOrder(Order dataModel);
        ValueTask AddOrderDetails(List<OrderDetails> models, int orderId);
        ValueTask<Order> GetOrderById(int Id);
        void TransactionStart();
        void TransactionCommit();
        void TransactioRollBack();
    }
}
