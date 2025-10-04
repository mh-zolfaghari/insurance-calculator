using InsuranceCalculator.Domain.Factories;

namespace InsuranceCalculator.Domain;

public static class ConfigureServices
{
    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services.AddDomainFactories();

        return services;
    }

    private static IServiceCollection AddDomainFactories(this IServiceCollection services)
    {
        services.AddScoped<ICoverageDefinitionFactory, CoverageDefinitionFactory>();
        services.AddScoped<IUserFactory, UserFactory>();
        services.AddScoped<IInsuranceRequestFactory, InsuranceRequestFactory>();
        services.AddScoped<ICoverageItemFactory, CoverageItemFactory>();

        return services;
    }
}
