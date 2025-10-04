using InsuranceCalculator.Application.Behaviors;
using InsuranceCalculator.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InsuranceCalculator.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Register Fluent validator.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //Register MediatR dependencies.
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ClientAuthorizationBehavior<,>));
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            if (configuration[$"{nameof(AppSettings)}:{nameof(AppSettings.LoggingBehavior)}"]?.ToLower() is "enable")
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        });

        return services;
    }
}
