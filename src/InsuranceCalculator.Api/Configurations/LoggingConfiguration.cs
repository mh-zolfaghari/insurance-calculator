using Microsoft.Extensions.Hosting;

namespace InsuranceCalculator.Api.Configurations;

public static class LoggingConfiguration
{
    public static void ConfigureLogging(this ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    }

    public static void ConfigureSeilog(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
    }
}
