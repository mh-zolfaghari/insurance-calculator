using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.Helpers;
using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Shared.Abstraction.Commons;
using InsuranceCalculator.Shared.Abstraction.Queries;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Queries.GetCurrentUserInsuranceRequests
{
    public class GetCurrentUserInsuranceRequestsQueryHandler
        (
            ICurrentUserContext currentUserContext,
            IInsuranceRequestRepository insuranceRequestRepository
        ) : IQueryHandler<GetCurrentUserInsuranceRequestsQuery, UserInsuranceRequestsDto>
    {
        private readonly ICurrentUserContext _currentUserContext = currentUserContext;
        private readonly IInsuranceRequestRepository _insuranceRequestRepository = insuranceRequestRepository;

        public async Task<Result<UserInsuranceRequestsDto>> Handle(GetCurrentUserInsuranceRequestsQuery request, CancellationToken cancellationToken)
        {
            var requestModel = request.ToRequestModel(_currentUserContext.UserId!.Value);
            var insuranceRequests = await _insuranceRequestRepository.GetAllWithUserIdAsync(requestModel, cancellationToken);
            return Result.Success(_currentUserContext.ToUserInsuranceRequestsDto(insuranceRequests));
        }
    }
}
