using MediatR;

namespace StockService.Domain.Entities.Events
{
    public class StockCancelledEvent : INotification
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public StockCancelledEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
