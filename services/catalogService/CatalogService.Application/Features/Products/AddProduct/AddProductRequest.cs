using CatalogService.Domain.ValueObjects;
using MediatR;

namespace CatalogService.Application.Features.Products.AddProduct
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
