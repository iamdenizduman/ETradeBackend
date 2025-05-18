using CatalogService.Domain.Entities.Abstracts;
using CatalogService.Domain.Exceptions;

namespace CatalogService.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        protected Category() { }
        public Category(string name)
        {
            UpdateName(name);
        }
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Kategori adı gereklidir.");

            Name = name;
        }
    }
}
