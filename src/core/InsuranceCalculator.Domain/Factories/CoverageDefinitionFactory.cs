using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

internal class CoverageDefinitionFactory : ICoverageDefinitionFactory
{
    public CoverageDefinition Create(BaseId id, string name, Price minimum, Price maximum, decimal premiumRate)
        => new(id, name, minimum, maximum, premiumRate);
}
