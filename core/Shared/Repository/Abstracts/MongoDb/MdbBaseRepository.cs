using MongoDB.Driver;
using Shared.Repository.Interfaces;
using System.Linq.Expressions;

namespace Shared.Repository.Abstracts.MongoDb
{
    public class MdbBaseRepository<T>: IMongoBaseRepository<T>
        where T : class
    {
        private readonly MongoDbService _mongoDbService;
        private IMongoCollection<T> _collections;
        public MdbBaseRepository(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
            _collections = mongoDbService.GetCollection<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _collections.InsertOneAsync(entity);
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await _collections.Find(_ => true).ToListAsync();
            }
            return await _collections.Find(predicate).ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collections.Find(predicate).SingleOrDefaultAsync();
        }
    }
}
