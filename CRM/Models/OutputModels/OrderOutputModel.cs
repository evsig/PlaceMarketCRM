using System.Collections.Generic;

namespace CRM.API.Models.OutputModels
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string PointName { get; set; }
        public List<OrderDetailsOutputModel> OrderDetailsOutput { get; set; }
    }
}
