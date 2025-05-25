using Shared.Repository.Interfaces;
using StockService.Domain.Entities;

namespace StockService.Application.Repository.Interfaces
{
    public interface IStockRepository : IMongoBaseRepository<Stock>
    {
    }
}
