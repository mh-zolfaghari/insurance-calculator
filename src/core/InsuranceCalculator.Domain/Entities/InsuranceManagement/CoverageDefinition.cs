using InsuranceCalculator.Domain.Exceptions;
using InsuranceCalculator.Domain.Primitives;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Entities.InsuranceManagement
{
    public class CoverageDefinition : BaseEntity
    {
        private readonly List<CoverageItem> _coverageItems = new();

        public string Name { get; private set; }
        public Price Minimum { get; private set; }
        public Price Maximum { get; private set; }
        public decimal PremiumRate { get; private set; }
        
        public IReadOnlyCollection<CoverageItem> CoverageItems => _coverageItems.AsReadOnly();

        private CoverageDefinition() { }

        internal CoverageDefinition
            (
                BaseId id,
                string name,
                Price minimum,
                Price maximum,
                decimal premiumRate
            )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CoverageDefinitionNameNullOrEmptyException();

            if (name.Length > 150)
                throw new CoverageDefinitionNameTooLongException();

            if (minimum.Amount > maximum.Amount)
                throw new InvalidCoverageDefinitionPriceMaxLessThanMinException();

            if (premiumRate <= 0)
                throw new InvalidCoverageDefinitionPremiumRateException();

            Id = id;
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
            PremiumRate = premiumRate;
        }

        public bool IsAmountWithinRange(Price amount)
            => amount.Amount >= Minimum.Amount && amount.Amount <= Maximum.Amount;

        public Price CalculatePremium(Price capital)
            => new(Math.Round(capital.Amount * PremiumRate, 2));
    }
}
