﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Models
{
    public class Point
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
