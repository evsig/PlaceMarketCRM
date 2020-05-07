﻿
using System;
using System.Collections.Generic;

namespace CRM.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public Point Point { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
