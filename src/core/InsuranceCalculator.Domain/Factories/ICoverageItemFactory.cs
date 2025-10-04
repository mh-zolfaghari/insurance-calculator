using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

public interface ICoverageItemFactory
{
    CoverageItem Create
        (
            BaseId id,
            BaseId coverageDefinitionId,
            BaseId insuranceRequestId,
            Price capital,
            Price premium
        );
}
