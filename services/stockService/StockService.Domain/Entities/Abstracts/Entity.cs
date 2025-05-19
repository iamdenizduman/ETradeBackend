using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StockService.Domain.Entities.Abstracts
{
    public abstract class Entity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
