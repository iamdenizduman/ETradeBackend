using Shared.Entity.Interfaces;

namespace Shared.Entity.Abstracts
{
    public abstract class BaseEntity : IEntity
    {
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
