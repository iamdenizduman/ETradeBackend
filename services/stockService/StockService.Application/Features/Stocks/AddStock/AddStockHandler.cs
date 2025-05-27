using MediatR;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;

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
            var stock = new Stock(request.ProductId, request.Quantity);
            string errMsg = string.Empty;
            try
            {
                await _stockRepository.AddAsync(stock);

                foreach (var domainEvent in stock.DomainEvents)
                {
                    await _mediator.Publish(domainEvent, cancellationToken);
                }
                stock.ClearDomainEvents();

                return new AddStockResponse
                {
                    isSuccess = true,
                    ProductId = stock.ProductId
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new AddStockResponse
            {
                isSuccess = false,
                ProductId = stock.ProductId,
                text = errMsg
            };
        }
    }
}
