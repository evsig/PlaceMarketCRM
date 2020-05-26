using System.Collections.Generic;
namespace CRM.API.Models.InputModels
{
    public class OrderInputModel 
    {
        public int WarehouseId { get; set; }
        public List<OrderProductInputModel> OrderDetailsList { get; set; }
    }
}
