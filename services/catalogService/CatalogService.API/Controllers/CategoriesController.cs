using CatalogService.Application.Features.Categories.AddCategory;
using CatalogService.Application.Features.Categories.GetAllCategories;
using CatalogService.Application.Features.Categories.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(AddCategory))]
        public async Task<IActionResult> AddCategory(AddCategoryRequest request)
        {
            var res = await _mediator.Send(request);            
            return Ok(res);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var res = await _mediator.Send(new GetAllCategoriesRequest());
            return Ok(res);
        }

        [HttpGet("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var req = new GetCategoryRequest()
            {
                CategoryId = categoryId
            };
            var res = await _mediator.Send(req);
            return Ok(res);
        }
    }
}
