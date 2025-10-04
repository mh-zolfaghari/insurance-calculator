using InsuranceCalculator.Application.Extensions;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Queries.GetCurrentUserInsuranceRequests
{
    public class GetCurrentUserInsuranceRequestsQueryValidator : AbstractValidator<GetCurrentUserInsuranceRequestsQuery>
    {
        public GetCurrentUserInsuranceRequestsQueryValidator()
        {
            this.PaginateValidator();
        }
    }
}
