using Shared.Entity.Abstracts;

namespace AuthService.Domain.Entities
{
    public class OperationClaim : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
