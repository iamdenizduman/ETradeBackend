using CatalogService.Application.Repository.Interfaces;
using CatalogService.Persistence.Repository.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository.Abstracts.MongoDb;

namespace CatalogService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string sqlConnection, string databaseName)
        {
            services.AddScoped(provider => new MongoDbService(sqlConnection, databaseName));
            services.AddScoped<ICategoryRepository, MdbCategoryRepository>();
            services.AddScoped<IProductRepository, MdbProductRepository>();
        }
    }
}
