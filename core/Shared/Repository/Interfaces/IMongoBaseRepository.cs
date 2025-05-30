using System.Linq.Expressions;

namespace Shared.Repository.Interfaces
{
    public interface IMongoBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(string id, T updatedEntity);
    }
}
