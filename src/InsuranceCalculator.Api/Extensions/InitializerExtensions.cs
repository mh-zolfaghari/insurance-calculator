using InsuranceCalculator.Domain.SeedData;

namespace InsuranceCalculator.Api.Extensions;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IApplicationDatabaseInitializer>();
        await initializer.InitializeDataBaseAsync();
        await initializer.SeedDataAsync();
    }
}