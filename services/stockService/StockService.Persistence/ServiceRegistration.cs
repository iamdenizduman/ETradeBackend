using Microsoft.Extensions.DependencyInjection;
using Shared.Repository.Abstracts.MongoDb;
using StockService.Application.Repository.Interfaces;
using StockService.Persistence.Repository.MongoDb;

namespace StockService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string sqlConnection, string databaseName)
        {
            services.AddScoped(provider => new MongoDbService(sqlConnection, databaseName));
            services.AddScoped<IStockRepository, MdbStockRepository>();
            services.AddScoped<IStockHistoryRepository, MdbStockHistoryRepository>();
        }
    }
}
