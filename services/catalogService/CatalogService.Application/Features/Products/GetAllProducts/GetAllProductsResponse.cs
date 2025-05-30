using CatalogService.Application.Models.Dtos;
using Shared.Entity.Abstracts;

namespace CatalogService.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsResponse : BaseResponse
    {
        public List<GetProductDto> GetProductDtos { get; set; }
    }
}
