namespace Core.Products
{
    public interface IProduct
    {
        string Title { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
        int ColumnsCount { get; set; }
    }
}
