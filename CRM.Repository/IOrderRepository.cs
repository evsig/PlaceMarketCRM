using CRM.DB.Models;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface IOrderRepository
    {
        ValueTask<RequestResult<Order>> AddOrder(Order dataModel);
    }
}
