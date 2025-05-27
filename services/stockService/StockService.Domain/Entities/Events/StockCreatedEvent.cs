using MediatR;

namespace StockService.Domain.Entities.Events
{
    public class StockCreatedEvent : INotification
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public StockCreatedEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
