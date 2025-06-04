using BasketService.Domain.Abstracts;

namespace BasketService.Domain.Entities
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items;
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public Basket(string buyerId)
        {
            if (string.IsNullOrWhiteSpace(buyerId))
                throw new ArgumentException("BuyerId cannot be empty");

            BuyerId = buyerId;
            _items = new List<BasketItem>();
        }
        public void AddItem(string productId, string productName, decimal unitPrice, int quantity = 1)
        {
            var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                var newItem = new BasketItem(productId, productName, unitPrice, quantity);
                _items.Add(newItem);
            }
        }
        public void DecreaseItemQuantity(string productId, int quantity = 1)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) return;

            item.DecreaseQuantity(quantity);

            if (item.Quantity <= 0)
                _items.Remove(item);
        }
        public void RemoveItem(string productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
                _items.Remove(item);
        }
        public void Clear() => _items.Clear();

    }
}
