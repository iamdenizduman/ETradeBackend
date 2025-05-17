using AuthService.Application.Repository.Interfaces;
using AuthService.Persistence.Repository.EntityFramework;
using AuthService.Persistence.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository.Abstracts.EntityFramework;
using Shared.Repository.Interfaces;

namespace AuthService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string sqlConnection)
        {
            services.AddDbContext<AuthDbContext>(opt =>
            {
                opt.UseSqlServer(sqlConnection);
            });

            services.AddScoped<IUserReadRepository, EfUserReadRepository>();
            services.AddScoped<IUserWriteRepository, EfUserWriteRepository>();
            services.AddScoped<IUserOperationClaimReadRepository, EfUserOperationClaimReadRepository>();
            services.AddScoped<IUserOperationClaimWriteRepository, EfUserOperationClaimWriteRepository>();
            services.AddScoped<IOperationClaimReadRepository, EfOperationClaimReadRepository>();
            services.AddScoped<IOperationClaimWriteRepository, EfOperationClaimWriteRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork<AuthDbContext>>();
        }
    }
}
