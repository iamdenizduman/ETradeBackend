using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Repository.Interfaces;
using MediatR;

namespace CatalogService.Application.Features.Categories.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                return new GetAllCategoriesResponse
                {
                    isSuccess = true,
                    Categories = categories.Select(c => new GetCategoryDto
                    {
                        Name = c.Name,
                        Id = c.Id
                    }).ToList(),
                    text = "Kategoriler başarıyla getirildi"
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new GetAllCategoriesResponse
            {
                isSuccess = false,
                Categories = null,
                text = "Kategoriler getirilirken hata"
            };
        }
    }
}
