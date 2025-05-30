using CatalogService.Domain.ValueObjects;

namespace CatalogService.Application.Models.Dtos
{
    public class GetProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
        public string Image { get; set; }
    }
}
