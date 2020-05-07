
using System;

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
