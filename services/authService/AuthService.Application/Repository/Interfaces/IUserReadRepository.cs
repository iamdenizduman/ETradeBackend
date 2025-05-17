using AuthService.Domain.Entities;
using Shared.Repository.Interfaces;

namespace AuthService.Application.Repository.Interfaces
{
    public interface IUserReadRepository : IEntityReadRepository<User>
    {
        Task<User?> GetUserWithClaimsAsync(string email);
    }
}
