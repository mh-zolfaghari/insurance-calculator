using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

public interface IInsuranceRequestFactory
{
    InsuranceRequest Create
        (
            BaseId id,
            BaseId userId,
            string title,
            DateTime createdAt
        );
}
