using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.RequestModels;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Domain.Repositories.InsuranceManagement;

public interface IInsuranceRequestRepository
{
    Task<Result> AddAsync(InsuranceRequest insuranceRequest, CancellationToken cancellationToken);
    Task<IReadOnlyList<InsuranceRequest>?> GetAllWithUserIdAsync(UserInsuranceRequestModel request, CancellationToken cancellationToken);
}
