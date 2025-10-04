using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Domain.RequestModels
{
    public record UserInsuranceRequestModel
        (
            BaseId UserId,
            int? Page,
            int? PageSize
        ) : IPaginateable;
}
