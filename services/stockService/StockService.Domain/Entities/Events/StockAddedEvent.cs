using MediatR;

namespace StockService.Domain.Entities.Events
{
    public class StockAddedEvent : INotification
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public StockAddedEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
