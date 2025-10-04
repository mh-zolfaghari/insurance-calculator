using InsuranceCalculator.Domain.Exceptions;

namespace InsuranceCalculator.Domain.ValueObjects
{
    public readonly record struct Price : IEquatable<Price>
    {
        public decimal Amount { get; private init; }

        public Price(decimal amount)
        {
            if (amount < 0)
                throw new InvalidPriceException();

            Amount = amount;
        }

        public static implicit operator decimal(Price price) => price.Amount;
        public static implicit operator Price(decimal amount) => new(amount);

        public bool Equals(Price? other) => other is not null && Amount == other?.Amount;
        public override int GetHashCode() => Amount.GetHashCode();
        public override string ToString() => Amount.ToString("F2");
    }
}
