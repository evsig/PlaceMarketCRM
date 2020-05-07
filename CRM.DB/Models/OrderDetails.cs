namespace CRM.DB.Models
{
    public class OrderDetails
    {
        public int? Id { get; set; }
        public int? OrderID { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}
