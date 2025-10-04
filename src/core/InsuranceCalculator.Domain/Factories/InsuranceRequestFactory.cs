using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

internal class InsuranceRequestFactory : IInsuranceRequestFactory
{
    public InsuranceRequest Create(BaseId id, BaseId userId, string title, DateTime createdAt)
        => new(id, userId, title, createdAt);
}
