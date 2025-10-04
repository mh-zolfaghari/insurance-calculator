using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.Factories;
using InsuranceCalculator.Domain.SeedData;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Context
{
    internal sealed class ApplicationDatabaseInitializer
        (
            AppDbContext dbContext,
            ILogger<ApplicationDatabaseInitializer> logger,
            ICoverageDefinitionFactory coverageDefinitionFactory,
            IUserFactory userFactory
        ) : IApplicationDatabaseInitializer
    {
        public async Task InitializeDataBaseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger?.LogCritical(ex, "DataBase_Initialization_Exception");
                throw;
            }
        }

        public async Task SeedDataAsync(CancellationToken cancellationToken = default)
        {
            using var dbTransaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await SeedDefinationCoverageDataAsync(cancellationToken);
                await SeedUserDataAsync(cancellationToken);

                await dbTransaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync(cancellationToken);
                logger?.LogCritical(ex, "DataBase_Seeding_Exception");
                throw;
            }
        }

        private async Task SeedDefinationCoverageDataAsync(CancellationToken cancellationToken)
        {
            if (!dbContext.CoverageDefinitions.Any())
            {
                var coverageDefinitions = new List<CoverageDefinition>
                {
                    coverageDefinitionFactory.Create(BaseId.NewId(), "پوشش جراحی", new(5000), new(500000000), 0.0052m),
                    coverageDefinitionFactory.Create(BaseId.NewId(), "پوشش دندانپزشکی", new(4000), new(400000000), 0.0042m),
                    coverageDefinitionFactory.Create(BaseId.NewId(), "پوشش بستری", new(2000), new(200000000), 0.005m),
                };
                dbContext.CoverageDefinitions.AddRange(coverageDefinitions);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task SeedUserDataAsync(CancellationToken cancellationToken)
        {
            if (!dbContext.Users.Any())
            {
                var users = new List<User>
                {
                    userFactory.Create(BaseId.NewId(), Guid.NewGuid(), "محمدحسین", "ذوالفقاری"),
                    userFactory.Create(BaseId.NewId(), Guid.NewGuid(), "الهام", "رضایی"),
                };
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
