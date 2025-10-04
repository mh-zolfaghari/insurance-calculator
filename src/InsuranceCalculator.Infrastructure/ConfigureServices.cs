using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Domain.Repositories.UserManagement;
using InsuranceCalculator.Domain.SeedData;
using InsuranceCalculator.Infrastructure.Persistence.EF.Context;
using InsuranceCalculator.Infrastructure.Persistence.EF.Repositories;

namespace InsuranceCalculator.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .RegisterApplicationDbContextServices(configuration)
                .RegisterRepositories();
        }

        private static IServiceCollection RegisterApplicationDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext)), (db) => { db.MigrationsHistoryTable("MigrationHistory"); })
                   .LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IApplicationDatabaseInitializer, ApplicationDatabaseInitializer>();

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDatabaseInitializer, ApplicationDatabaseInitializer>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInsuranceRequestRepository, InsuranceRequestRepository>();
            services.AddScoped<ICoverageDefinitionRepository, CoverageDefinitionRepository>();

            return services;
        }
    }
}
