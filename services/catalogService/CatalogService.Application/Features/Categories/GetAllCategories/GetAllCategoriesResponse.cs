using CatalogService.Application.Models.Dtos;
using Shared.Entity.Abstracts;

namespace CatalogService.Application.Features.Categories.GetAllCategories
{
    public class GetAllCategoriesResponse : BaseResponse
    {
        public List<GetCategoryDto> Categories { get; set; }
    }
}
