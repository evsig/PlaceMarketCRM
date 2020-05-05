using CRM.DB.Models;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public interface IProductStorage
    {
        ValueTask<Product> GetProductById(int id);
    }
}
