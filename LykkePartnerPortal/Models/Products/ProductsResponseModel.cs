using Core.Products;
using System.Collections.Generic;

namespace LykkePartnerPortal.Models.Products
{
    public class ProductsResponseModel
    {
        public IEnumerable<IProduct> Products { get; set; }
    }
}
