namespace CRM.API.Models.OutputModels
{
    public class OrderProductOutputModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal LocalPrice { get; set; }
        public string TradeMark { get; set; }
        public string Model { get; set; }
        public string SubCategoryName { get; set; }
    }
}
