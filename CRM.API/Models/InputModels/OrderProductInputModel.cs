namespace CRM.API.Models.InputModels
{
    public class OrderProductInputModel 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LocalPrice { get; set; }
    }
}
