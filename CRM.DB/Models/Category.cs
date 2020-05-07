namespace CRM.DB.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Category Subcategory { get; set; }
        public int? CountProducts { get; set; }
    }
}
