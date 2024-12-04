namespace Nest.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public List<Product> Products { get; set; }



    }
}
