using Shared.Entity.Abstracts;

namespace CatalogService.Application.Features.Products.AddProduct
{
    public class AddProductResponse : BaseResponse
    {
        public string Name { get; set; }
    }
}
