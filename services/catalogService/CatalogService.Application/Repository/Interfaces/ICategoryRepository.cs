using CatalogService.Domain.Entities;
using Shared.Repository.Interfaces;

namespace CatalogService.Application.Repository.Interfaces
{
    public interface ICategoryRepository : IMongoBaseRepository<Category> 
    {
    }
}
