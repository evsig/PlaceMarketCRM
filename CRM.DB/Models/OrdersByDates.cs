namespace CRM.DB.Models
{
    public class OrdersByDates : Order
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Cash { get; set; }
    }
}
