namespace BasketService.Domain.Entities
{
    public class BasketItem 
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public BasketItem(string productId, string productName, decimal unitPrice, int quantity = 1)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be at least 1");

            if (string.IsNullOrEmpty(productId))
                throw new ArgumentException("ProductId mustn't be null");

            if (unitPrice <= 0)
                throw new ArgumentException("Unit price mustn't be smaller than 0");

            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0");

            Quantity += amount;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0");

            Quantity -= amount;

            if (Quantity < 0)
                throw new ArgumentException("Amount must be greater than 0");
        }

        public void UpdateUnitPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be greater than 0");

            UnitPrice = newPrice;
        }
    }
}
