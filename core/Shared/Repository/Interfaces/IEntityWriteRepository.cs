using Shared.Entity.Interfaces;

namespace Shared.Repository.Interfaces
{
    public interface IEntityWriteRepository<T>
        where T : class, IEntity
    {
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
