using MediatR;

namespace CatalogService.Application.Features.Categories.AddCategory
{
    public class AddCategoryRequest : IRequest<AddCategoryResponse>
    {
        public string Name { get; set; }
    }
}
