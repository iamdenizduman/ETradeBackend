using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StockService.Domain.Entities.Abstracts;
using StockService.Domain.Enums;

namespace StockService.Domain.Entities
{
    public class StockHistory : Entity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid StockId { get; private set; }
        public int Quantity { get; private set; }
        public StockHistoryType HistoryType { get; private set; }
        protected StockHistory() { }
        public StockHistory(Guid stockId, int quantity, StockHistoryType historyType) 
        {
            StockId = stockId;
            Quantity = quantity;
            HistoryType = historyType;
        }
    }
}
