using CatalogService.Application.Repository.Interfaces;
using CatalogService.Domain.Entities;
using Shared.Repository.Abstracts.MongoDb;

namespace CatalogService.Persistence.Repository.MongoDb
{
    public class MdbProductRepository : MdbBaseRepository<Product>, IProductRepository
    {
        public MdbProductRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}

