using Microsoft.EntityFrameworkCore;
using Shared.Entity.Interfaces;
using Shared.Repository.Interfaces;

namespace Shared.Repository.Abstracts.EntityFramework
{
    public abstract class EfEntityWriteRepository<T>(DbContext context) : IEntityWriteRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
