using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Models
{
    public class Subcategory
    {
        public int? Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

    }
}
