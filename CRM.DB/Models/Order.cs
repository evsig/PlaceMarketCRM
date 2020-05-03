using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int CountOfGood { get; set; }
        public DateTime OnsaleDate { get; set; }
    }
}
