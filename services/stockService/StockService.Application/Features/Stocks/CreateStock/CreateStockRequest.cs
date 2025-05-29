using MediatR;

namespace StockService.Application.Features.Stocks.CreateStock
{
    public class CreateStockRequest : IRequest<CreateStockResponse>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
