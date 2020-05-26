namespace CRM.API.Models.OutputModels
{
    public class OrdersByDatesOutputModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string StoreName { get; set; }
        public int CountProduct { get; set; }
        public decimal TotalSum { get; set; }
        public string TradeMark { get; set; }
        public string Model { get; set; }
        public string SubCategoryName { get; set; }
    }
}
/*namespace CRM.API.Models.OutputModels
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
}*/
