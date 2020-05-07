namespace CRM.API.Models.InputModels
{
    public class OrderDetailsInputModel
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
