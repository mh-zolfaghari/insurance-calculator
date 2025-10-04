using InsuranceCalculator.Api.Controllers.Base;
using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.UseCases.User.Queries;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Api.Controllers;

public class UserController(ISender sender) : BaseController(sender)
{
    [HttpGet("/api/users")]
    [ProducesResponseType(typeof(Result<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetUsersQuery query, CancellationToken cancellationToken = default)
            => OkResult(await MediatR.Send(query, cancellationToken));
}
