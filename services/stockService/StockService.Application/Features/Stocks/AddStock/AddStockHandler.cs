using MediatR;
using StockService.Application.Repository.Interfaces;

namespace StockService.Application.Features.Stocks.AddStock
{
    public class AddStockHandler : IRequestHandler<AddStockRequest, AddStockResponse>
    {
        readonly IStockRepository _stockRepository;
        readonly IMediator _mediator;

        public AddStockHandler(IStockRepository stockRepository, IMediator mediator)
        {
            _stockRepository = stockRepository;
            _mediator = mediator;
        }

        public async Task<AddStockResponse> Handle(AddStockRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var stock = await _stockRepository.GetAsync(s => s.ProductId.ToString() == request.ProductId.ToString());

                if (stock == null)
                {
                    return new AddStockResponse
                    {
                        isSuccess = false,
                        ProductId = request.ProductId,
                        text = "Stok bulunamadı"
                    };
                }

                stock!.Added(request.Quantity);
                
                await _stockRepository.UpdateAsync(stock.Id.ToString(), stock);

                foreach (var domainEvent in stock.DomainEvents)
                {
                    await _mediator.Publish(domainEvent, cancellationToken);
                }

                stock!.ClearDomainEvents();

                return new AddStockResponse
                {
                    isSuccess = true,
                    ProductId = stock.ProductId,
                    text = $"{request.Quantity} adet stok eklendi"
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new AddStockResponse
            {
                isSuccess = false,
                ProductId = request.ProductId,
                text = errMsg
            };
        }
    }

}
