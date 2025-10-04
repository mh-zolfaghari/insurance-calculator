using InsuranceCalculator.Api.Controllers.Base;
using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.UseCases.CoverageDefinition.Queries.GetCoverageDefinations;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Api.Controllers;

public class CoverageDefinationController(ISender sender) : BaseController(sender)
{
    [HttpGet("/api/coverage-definations")]
    [ProducesResponseType(typeof(Result<IEnumerable<CoverageDefinationDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetCoverageDefinationsQuery query, CancellationToken cancellationToken = default)
            => OkResult(await MediatR.Send(query, cancellationToken));
}