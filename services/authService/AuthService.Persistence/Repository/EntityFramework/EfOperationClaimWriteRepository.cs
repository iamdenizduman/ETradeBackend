using AuthService.Application.Repository.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Persistence.Repository.EntityFramework.Context;
using Shared.Repository.Abstracts.EntityFramework;

namespace AuthService.Persistence.Repository.EntityFramework
{
    public class EfOperationClaimWriteRepository(AuthDbContext context) : EfEntityWriteRepository<OperationClaim>(context), IOperationClaimWriteRepository
    {
    }
}
