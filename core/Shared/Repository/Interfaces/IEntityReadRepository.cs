using Shared.Entity.Interfaces;
using System.Linq.Expressions;

namespace Shared.Repository.Interfaces
{
    public interface IEntityReadRepository<T>
        where T : class, IEntity
    {
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
