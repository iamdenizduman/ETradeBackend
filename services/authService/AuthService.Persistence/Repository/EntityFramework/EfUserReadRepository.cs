using AuthService.Application.Repository.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Persistence.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Repository.Abstracts.EntityFramework;

namespace AuthService.Persistence.Repository.EntityFramework
{
    public class EfUserReadRepository : EfEntityReadRepository<User>, IUserReadRepository
    {
        private readonly AuthDbContext _context;
        public EfUserReadRepository(AuthDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserWithClaimsAsync(string email)
        {
            return await _context.Users.Include(u => u.UserOperationClaims)
                .ThenInclude(uoc => uoc.OperationClaim)
                .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
