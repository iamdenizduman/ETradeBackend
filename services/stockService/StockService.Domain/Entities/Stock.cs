using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StockService.Domain.Entities.Abstracts;
using StockService.Domain.Entities.Events;
using StockService.Domain.Exceptions;

namespace StockService.Domain.Entities
{
    public class Stock : AggregateRoot
    {
        [BsonRepresentation(BsonType.String)]
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        private List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;

        protected Stock() { }

        public Stock(Guid productId, int quantity) 
        {
            ProductId = productId;
            Quantity = quantity;
            InsertDate = DateTime.Now;
            AddDomainEvent(new StockCreatedEvent(productId, quantity));
        }
        
        public bool HasSufficientStock(int amount) => Quantity >= amount;

        public void Added(int amount)
        {
            Quantity += amount;
            AddDomainEvent(new StockAddedEvent(ProductId, amount));
        }

        public void Sold(int amount)
        {
            if (amount > Quantity)
                throw new DomainException("Stok yeterli değil");
            Quantity -= amount;
            AddDomainEvent(new StockSoldEvent(ProductId, amount));
        }

        public void Cancelled(int amount)
        {
            Quantity += amount;
            AddDomainEvent(new StockCancelledEvent(ProductId, amount));
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
