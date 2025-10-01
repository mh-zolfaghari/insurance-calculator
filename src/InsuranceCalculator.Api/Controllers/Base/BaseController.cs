using InsuranceCalculator.Api.Extensions;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    internal abstract class BaseController : Controller
    {
        protected IActionResult OkResult<T>(Result<T> response)
            => response.Error.Type == ErrorType.None
                ? Ok(response)
                : CreateProblemResult(response.MapToProblemDetails());

        protected IActionResult OkResult(Result response)
            => response.Error.Type == ErrorType.None
                ? Ok(response)
                : CreateProblemResult(response.MapToProblemDetails());

        private IActionResult CreateProblemResult(ProblemDetails problemDetails)
            => Problem
                (
                    detail: problemDetails.Detail,
                    instance: problemDetails.Instance,
                    statusCode: problemDetails.Status,
                    title: problemDetails.Title,
                    type: problemDetails.Type
                );
    }
}
