namespace CatalogService.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right) =>
            left?.Equals(right) ?? right is null;

        protected static bool NotEqualOperator(ValueObject left, ValueObject right) =>
            !(EqualOperator(left, right));

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
        }
    }

}
