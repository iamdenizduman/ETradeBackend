using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Repository.Interfaces;
using MediatR;

namespace CatalogService.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var products = await _productRepository.GetAllAsync();
                var getProductDtos = products.Select(p => new GetProductDto
                {
                    Id = p.Id,
                    CategoryId = p.CategoryId,
                    Image = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

                return new GetAllProductsResponse
                {
                    GetProductDtos = getProductDtos,
                    isSuccess = true,
                    text = "Ürünler başarıyla getirildi"
                };
            }
            catch (Exception ex)
            {
               errMsg = ex.Message;
            }

            return new GetAllProductsResponse
            {
                GetProductDtos = null,
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
