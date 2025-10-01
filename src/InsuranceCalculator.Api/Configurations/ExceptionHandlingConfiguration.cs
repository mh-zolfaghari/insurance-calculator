using InsuranceCalculator.Api.Middlewares;

namespace InsuranceCalculator.Api.Configurations;

public static class ExceptionHandlingConfiguration
{
    public static void ConfigureExceptionHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
}
