using AuthService.Application.Authentication.Interfaces;
using AuthService.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IHashingHelper, HashingHelper>();
        }
    }
}
