namespace Core.Products
{
    public class Product : IProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ColumnsCount { get; set; }
    }
}
