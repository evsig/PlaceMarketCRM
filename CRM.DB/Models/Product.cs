using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TradeMarkId { get; set; }
        public int ModelId { get; set; }
        public Category Category { get; set; }
        public int SubcategoryId { get; set; }
    }
}
/*SELECT TOP (1000) [Id]
      ,[Name]
      ,[Price]
      ,[TradeMarkId]
      ,[ModelId]
      ,[CategoryId]
      ,[SubcategoryId]
  FROM [DevEduHomeWork].[dbo].[Good]*/
