using BasketService.Domain.Entities;
using Shared.Caching.Interfaces.Redis;

namespace BasketService.Application.Caching.Interfaces
{
    public interface IBasketCache : IRedisCache
    {
        Task<Basket> GetByBuyerIdAsync(string buyerId);
        Task AddAsync(Basket basket);
        Task UpdateAsync(Basket basket);
    }
}
