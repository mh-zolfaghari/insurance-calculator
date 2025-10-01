namespace InsuranceCalculator.Api.Extensions;

public static class EnvironmentExtensions
{
    public static void RegisterMiddlewaresInProductionMode(this WebApplication? app, Action @action)
    {
        if (app?.Environment.IsProduction() ?? false)
            @action();
    }

    public static void RegisterMiddlewaresInDevelopmentMode(this WebApplication? app, Action @action)
    {
        if (app?.Environment.IsDevelopment() ?? false)
            @action();
    }
}
