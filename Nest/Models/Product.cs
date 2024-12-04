namespace Nest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? SKU{ get; set; }
        public int? InStock { get; set; }
        public int Price { get; set; }
        public int? LifeTime { get; set; }
        public List<TagProduct>? TagProducts { get; set; }
        public int? CategoryId { get; set; }
        public List<Category>? Categories { get; set; }


    }
}
