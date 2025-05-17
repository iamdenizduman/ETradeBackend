using AuthService.Domain.Entities;
using Shared.Repository.Interfaces;

namespace AuthService.Application.Repository.Interfaces
{
    public interface IOperationClaimReadRepository : IEntityReadRepository<OperationClaim>
    {
    }
}
