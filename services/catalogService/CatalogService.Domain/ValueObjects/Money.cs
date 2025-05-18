using CatalogService.Domain.Exceptions;

namespace CatalogService.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        protected Money() { }
        public Money(decimal amount, string currency = "TRY")
        {
            if (amount < 0)
                throw new DomainException("Tutar negatif olamaz.");

            Amount = amount;
            Currency = currency;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }

}
