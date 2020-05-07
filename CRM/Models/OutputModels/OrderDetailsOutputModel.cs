using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models.OutputModels
{
    public class OrderDetailsOutputModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string TradeMark { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
