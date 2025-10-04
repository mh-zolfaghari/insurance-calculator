using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

internal class CoverageItemFactory : ICoverageItemFactory
{
    public CoverageItem Create(BaseId id, BaseId coverageDefinitionId, BaseId insuranceRequestId, Price capital, Price premium)
        => new(id, coverageDefinitionId, insuranceRequestId, capital, premium);
}
