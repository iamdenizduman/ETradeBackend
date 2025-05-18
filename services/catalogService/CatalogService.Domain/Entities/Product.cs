using CatalogService.Domain.Entities.Abstracts;
using CatalogService.Domain.Exceptions;
using CatalogService.Domain.ValueObjects;

namespace CatalogService.Domain.Entities
{
    public class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public string ImageUrl { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        protected Product() { } 
        public Product(string name, string description, Money price, string imageUrl, Guid categoryId)
        {
            UpdateName(name);
            UpdatePrice(price);
            UpdateCategory(categoryId);
            Description = description;
            ImageUrl = imageUrl;
        }
        public void UpdatePrice(Money newPrice)
        {
            if (newPrice.Amount <= 0)
                throw new DomainException("Tutar 0'dan büyük olmalıdır.");

            Price = newPrice;
        }
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Ürün adı gereklidir.");

            Name = name;
        }
        public void UpdateCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new DomainException("Kategori id gereklidir.");
            
            CategoryId = categoryId;
        }
    }
}
