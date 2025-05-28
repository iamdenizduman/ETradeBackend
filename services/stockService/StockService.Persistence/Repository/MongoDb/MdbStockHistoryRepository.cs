using Shared.Repository.Abstracts.MongoDb;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;

namespace StockService.Persistence.Repository.MongoDb
{
    public class MdbStockHistoryRepository : MdbBaseRepository<StockHistory>, IStockHistoryRepository
    {
        public MdbStockHistoryRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}

