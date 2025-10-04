namespace InsuranceCalculator.Domain.SeedData;

public interface IApplicationDatabaseInitializer
{
    Task InitializeDataBaseAsync(CancellationToken cancellationToken = default);
    Task SeedDataAsync(CancellationToken cancellationToken = default);
}
