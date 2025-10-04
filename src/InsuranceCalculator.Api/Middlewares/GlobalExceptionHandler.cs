using InsuranceCalculator.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace InsuranceCalculator.Api.Middlewares;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, CancellationToken, Task>> _exceptionHandlers;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
        _exceptionHandlers = new()
            {
                { typeof(BusinessValidationException), HandleBusinessValidationException },
                { typeof(ClientUnAuthorizedException), HandleClientUnAuthorizedException },
            };
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Server Error happened!");

        var exceptionType = exception.GetType();
        if (_exceptionHandlers.TryGetValue(exceptionType, out var handler))
        {
            await handler.Invoke(httpContext, exception, cancellationToken);
            return true;
        }

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server error"
        }, cancellationToken);

        return false;
    }

    private async Task HandleBusinessValidationException(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Validation error happened!");

        var businessValidationException = (BusinessValidationException)exception;
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation error",
            Detail = "One or more validation errors has occurred",
        };

        if (businessValidationException.Errors is not null)
            problemDetails.Extensions["errors"] = businessValidationException.Errors;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }

    private async Task HandleClientUnAuthorizedException(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "UnAuthorized client error happened!");

        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "UnAuthorized Client",
            Detail = "Token is not sent or Client is unauthorized :(",
        }, cancellationToken);
    }
}
