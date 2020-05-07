namespace CRM.API.Models.OutputModels
{
    public class OrderPeriodOutputModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Point { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
