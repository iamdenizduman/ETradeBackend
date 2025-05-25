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
        private StockHistory(Guid stockId, int quantity, StockHistoryType historyType) 
        {
            StockId = stockId;
            Quantity = quantity;
            HistoryType = historyType;
        }
        public static StockHistory Created(Guid stockId, int quantity)
        {
            return new StockHistory(stockId, quantity, StockHistoryType.Created);
        }
        public static StockHistory Added(Guid stockId, int quantity)
        {
            return new StockHistory(stockId, quantity, StockHistoryType.Added);
        }
        public static StockHistory Sold(Guid stockId, int quantity)
        {
            return new StockHistory(stockId, quantity, StockHistoryType.Sold);
        }
        public static StockHistory Cancelled (Guid stockId, int quantity)
        {
            return new StockHistory(stockId, quantity, StockHistoryType.Cancelled);
        }
    }
}
