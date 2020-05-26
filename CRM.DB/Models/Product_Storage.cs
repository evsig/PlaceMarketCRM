namespace CRM.DB.Models
{
    public class Product_CRMge
    {
        public int? Id { get; set; } 
        public Product Product { get; set; } 
        public Store Store { get; set; } 
        public int Quantity { get; set; } 
    }
}
