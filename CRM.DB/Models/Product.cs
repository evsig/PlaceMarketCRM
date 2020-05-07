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
