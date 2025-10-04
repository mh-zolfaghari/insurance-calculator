using InsuranceCalculator.Api.Controllers.Base;
using InsuranceCalculator.Api.Filters;
using InsuranceCalculator.Application.UseCases.InsuranceRequest.Commands.CreateInsuranceRequest;
using InsuranceCalculator.Application.UseCases.InsuranceRequest.Queries.GetCurrentUserInsuranceRequests;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Api.Controllers;

public class InsuranceRequestController(ISender sender) : BaseController(sender)
{
    [AuthorizeByToken]
    [HttpPost("/api/insurance-requests")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateInsuranceRequestCommand request, CancellationToken cancellationToken = default)
            => OkResult(await MediatR.Send(request, cancellationToken));

    [AuthorizeByToken]
    [HttpGet("/api/insurance-requests")]
    [ProducesResponseType(typeof(Result<GetCurrentUserInsuranceRequestsQuery>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromQuery] GetCurrentUserInsuranceRequestsQuery request, CancellationToken cancellationToken = default)
            => OkResult(await MediatR.Send(request, cancellationToken));
}
