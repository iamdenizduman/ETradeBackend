using Shared.Entity.Abstracts;

namespace StockService.Application.Features.Stocks.AddStock
{
    public class AddStockResponse : BaseResponse
    {
        public Guid ProductId { get; set; }
    }
}
