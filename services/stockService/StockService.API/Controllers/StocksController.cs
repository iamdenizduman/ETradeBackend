using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockService.Application.Features.Stocks.AddStock;
using StockService.Application.Features.Stocks.CreateStock;

namespace StockService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        readonly IMediator _mediator;

        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(CreateStock))]
        public async Task<IActionResult> CreateStock(CreateStockRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost(nameof(AddStock))]
        public async Task<IActionResult> AddStock(AddStockRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
