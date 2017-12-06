using Core.Products;
using Newtonsoft.Json;

namespace LykkePartnerPortal.Models.Products
{
    public class ProductResponseModel : IProduct
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "columnsCount")]
        public int ColumnsCount { get; set; }

        public static ProductResponseModel Create(IProduct product)
        {
            return new ProductResponseModel()
            {
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                ColumnsCount = product.ColumnsCount
            };
        }
    }
}
