using MediatR;

namespace StockService.Domain.Entities.Events
{
    public class StockSoldEvent : INotification
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public StockSoldEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
