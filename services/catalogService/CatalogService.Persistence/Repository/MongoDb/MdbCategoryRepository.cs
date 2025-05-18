using CatalogService.Application.Repository.Interfaces;
using CatalogService.Domain.Entities;
using Shared.Repository.Abstracts.MongoDb;

namespace CatalogService.Persistence.Repository.MongoDb
{
    public class MdbCategoryRepository : MdbBaseRepository<Category>, ICategoryRepository
    {
        public MdbCategoryRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}

