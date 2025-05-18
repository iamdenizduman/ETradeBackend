using CatalogService.Application.Models.Dtos;
using Shared.Entity.Abstracts;

namespace CatalogService.Application.Features.Categories.GetCategory
{
    public class GetCategoryResponse : BaseResponse
    {
        public GetCategoryDto Category { get; set; }
    }
}
