using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

public interface ICoverageDefinitionFactory
{
    CoverageDefinition Create
        (
            BaseId id,
            string name,
            Price minimum,
            Price maximum,
            decimal premiumRate
        );
}
