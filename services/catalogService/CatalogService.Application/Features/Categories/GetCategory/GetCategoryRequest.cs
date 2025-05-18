using MediatR;

namespace CatalogService.Application.Features.Categories.GetCategory
{
    public class GetCategoryRequest : IRequest<GetCategoryResponse>
    {
        public Guid CategoryId { get; set; }
    }
}
