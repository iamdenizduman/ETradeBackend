using Shared.Repository.Abstracts.MongoDb;
using StockService.Application.Repository.Interfaces;
using StockService.Domain.Entities;

namespace StockService.Persistence.Repository.MongoDb
{
    public class MdbStockRepository : MdbBaseRepository<Stock>, IStockRepository
    {
        public MdbStockRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}

