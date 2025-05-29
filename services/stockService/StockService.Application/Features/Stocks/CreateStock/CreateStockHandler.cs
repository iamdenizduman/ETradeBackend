using MediatR;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;

namespace StockService.Application.Features.Stocks.CreateStock
{
    public class CreateStockHandler : IRequestHandler<CreateStockRequest, CreateStockResponse>
    {
        readonly IStockRepository _stockRepository;
        readonly IMediator _mediator;

        public CreateStockHandler(IStockRepository stockRepository, IMediator mediator)
        {
            _stockRepository = stockRepository;
            _mediator = mediator;
        }

        public async Task<CreateStockResponse> Handle(CreateStockRequest request, CancellationToken cancellationToken)
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

                return new CreateStockResponse
                {
                    isSuccess = true,
                    ProductId = stock.ProductId
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new CreateStockResponse
            {
                isSuccess = false,
                ProductId = stock.ProductId,
                text = errMsg
            };
        }
    }
}
