using CatalogService.Application.Models.Dtos;
using CatalogService.Application.Repository.Interfaces;
using MediatR;

namespace CatalogService.Application.Features.Categories.GetCategory
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == request.CategoryId);
                if (category == null)
                {
                    return new GetCategoryResponse
                    {
                        isSuccess = false,                        
                        text = "Kategori bulunamadı",
                        Category = null
                    };
                }
                else
                {
                    return new GetCategoryResponse
                    {
                        isSuccess = true,
                        text = "Kategori başarıyla getirildi",
                        Category = new GetCategoryDto
                        {
                           Name = category.Name,
                           Id = category.Id
                        }
                    };
                }
                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return new GetCategoryResponse
            {
                isSuccess = false,
                text = errMsg,
                Category = null
            };
        }
    }
}
