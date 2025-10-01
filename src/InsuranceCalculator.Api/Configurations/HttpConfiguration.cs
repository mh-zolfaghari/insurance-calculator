namespace InsuranceCalculator.Api.Configurations;

public static class HttpConfiguration
{
    public static void ConfigureHttpSettings(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
    }
}
