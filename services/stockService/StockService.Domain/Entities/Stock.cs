using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StockService.Domain.Entities.Abstracts;
using StockService.Domain.Exceptions;

namespace StockService.Domain.Entities
{
    public class Stock : AggregateRoot
    {
        [BsonRepresentation(BsonType.String)]
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        protected Stock() { }

        public Stock(Guid productId, int quantity) 
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public bool HasSufficientStock(int amount) => Quantity >= amount;

        public void Increase(int amount) => Quantity += amount;

        public void Decrease(int amount)
        {
            if (amount > Quantity)
                throw new DomainException("Stok yeterli değil");
            Quantity -= amount;
        }
    }
}
