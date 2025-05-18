using CatalogService.Application.Repository.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Features.Categories.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            Category category = new Category(request.Name);
            try
            {
                await _categoryRepository.AddAsync(category);
                return new AddCategoryResponse
                {
                    Name = request.Name,
                    isSuccess = true,
                    text = "Kategori başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new AddCategoryResponse
            {
                Name = request.Name,
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
