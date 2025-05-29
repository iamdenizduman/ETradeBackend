using Shared.Entity.Abstracts;

namespace StockService.Application.Features.Stocks.CreateStock
{
    public class CreateStockResponse : BaseResponse
    {
        public Guid ProductId { get; set; }
    }
}
