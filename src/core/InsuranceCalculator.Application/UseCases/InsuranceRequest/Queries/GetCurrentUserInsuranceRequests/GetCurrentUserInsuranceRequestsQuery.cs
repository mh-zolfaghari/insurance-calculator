using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Shared.Abstraction.Commons;
using InsuranceCalculator.Shared.Abstraction.Queries;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Queries.GetCurrentUserInsuranceRequests;

public record GetCurrentUserInsuranceRequestsQuery : IQueryRequest<UserInsuranceRequestsDto>, IPaginateable
{
    public int? Page { get; init; }
    public int? PageSize { get; init; }
}
