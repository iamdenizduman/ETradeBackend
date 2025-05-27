using MediatR;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;
using StockService.Domain.Entities.Events;
using StockService.Domain.Enums;

namespace StockService.Application.Features.Events
{
    public class StockCreatedEventHandler : INotificationHandler<StockCreatedEvent>
    {
        private readonly IStockHistoryRepository _historyRepository;

        public StockCreatedEventHandler(IStockHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task Handle(StockCreatedEvent notification, CancellationToken cancellationToken)
        {
            var history = new StockHistory(notification.ProductId, notification.Quantity, StockHistoryType.Created);
            await _historyRepository.AddAsync(history);
        }
    }
}
