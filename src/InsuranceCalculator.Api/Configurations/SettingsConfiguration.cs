using InsuranceCalculator.Shared;

namespace InsuranceCalculator.Api.Configurations;

public static class SettingsConfiguration
{
    public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<AppSettings>()
            .Bind(configuration.GetSection(AppSettings.ConfigurationSectionName))
            .ValidateDataAnnotations();
    }
}
