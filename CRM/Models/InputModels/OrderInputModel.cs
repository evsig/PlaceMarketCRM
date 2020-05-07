using System.Collections.Generic;

namespace CRM.API.Models.InputModels
{
    public class OrderInputModel
    {
        public int PointId { get; set; }
        public List<OrderDetailsInputModel> OrderDetails { get; set; }
    }
}
