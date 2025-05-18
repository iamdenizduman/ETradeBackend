using Shared.Entity.Abstracts;

namespace CatalogService.Application.Features.Categories.AddCategory
{
    public class AddCategoryResponse : BaseResponse
    {
        public string Name { get; set; }
    }
}
