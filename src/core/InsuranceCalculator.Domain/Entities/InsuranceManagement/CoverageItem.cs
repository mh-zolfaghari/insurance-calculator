using InsuranceCalculator.Domain.Primitives;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Entities.InsuranceManagement;

public class CoverageItem : BaseEntity
{
    public BaseId CoverageDefinitionId { get; private set; }
    public BaseId InsuranceRequestId { get; private set; }
    public Price Capital { get; private set; }
    public Price Premium { get; private set; }

    public CoverageDefinition CoverageDefinition { get; private set; }
    public InsuranceRequest InsuranceRequest { get; private set; }

    private CoverageItem() { }

    internal CoverageItem
        (
            BaseId id,
            BaseId coverageDefinitionId,
            BaseId insuranceRequestId,
            Price capital,
            Price premium
        )
    {
        Id = id;
        CoverageDefinitionId = coverageDefinitionId;
        InsuranceRequestId = insuranceRequestId;
        Capital = capital;
        Premium = premium;
    }
}
