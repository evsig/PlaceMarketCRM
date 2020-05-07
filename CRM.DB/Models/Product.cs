namespace CRM.DB.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TradeMark { get; set; }
        public string Model { get; set; }
        public Category Category { get; set; }
        public int SubcategoryId { get; set; }
    }
}
