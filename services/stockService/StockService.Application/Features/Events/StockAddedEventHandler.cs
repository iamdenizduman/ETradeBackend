﻿using MediatR;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;
using StockService.Domain.Entities.Events;
using StockService.Domain.Enums;

namespace StockService.Application.Features.Events
{
    public class StockAddedEventHandler : INotificationHandler<StockAddedEvent>
    {
        private readonly IStockHistoryRepository _historyRepository;

        public StockAddedEventHandler(IStockHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task Handle(StockAddedEvent notification, CancellationToken cancellationToken)
        {
            var history = new StockHistory(notification.ProductId, notification.Quantity, StockHistoryType.Added);
            await _historyRepository.AddAsync(history);
        }
    }
}
