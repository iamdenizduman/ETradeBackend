using MediatR;

namespace StockService.Application.Features.Stocks.AddStock
{
    public class AddStockRequest : IRequest<AddStockResponse>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
