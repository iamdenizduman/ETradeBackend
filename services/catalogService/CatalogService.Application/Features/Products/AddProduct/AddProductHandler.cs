using CatalogService.Application.Repository.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Features.Products.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Name, request.Description, request.Price, request.ImageUrl, request.CategoryId);

            string errMsg = string.Empty;
            try
            {
                await _productRepository.AddAsync(product);
                return new AddProductResponse
                {
                    Name = product.Name,
                    isSuccess = true,
                    text = "Ürün başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new AddProductResponse
            {
                Name = product.Name,
                isSuccess = true,
                text = errMsg
            };
        }
    }
}
