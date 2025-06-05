using Shared.Caching.Interfaces.Redis;
using StackExchange.Redis;
using System.Text.Json;

namespace Shared.Caching.Abstracts.Redis
{
    public class RedisCache : IRedisCache
    {
        readonly RedisService _redisService;
        readonly IDatabase _db;

        public RedisCache(RedisService redisService)
        {
            _redisService = redisService;
            _db = _redisService.Database;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            return value.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(value);

            if (expiry == null) 
                expiry = TimeSpan.FromMinutes(10);

            await _db.StringSetAsync(key, json, expiry);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }        
    }
}
