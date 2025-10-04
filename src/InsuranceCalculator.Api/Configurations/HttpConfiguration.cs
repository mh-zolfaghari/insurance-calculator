using InsuranceCalculator.Api.Services;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Api.Configurations;

public static class HttpConfiguration
{
    public static void ConfigureHttpSettings(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserContext, CurrentUser>();
        services.AddHttpContextAccessor();
    }
}
