namespace InsuranceCalculator.Application.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var response = await next(cancellationToken);

        logger.LogInformation("Insurance Calculator Response: {requestName} {@Response}", requestName, response);

        return response;
    }
}
