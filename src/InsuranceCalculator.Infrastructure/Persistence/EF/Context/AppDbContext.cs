using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Infrastructure.Persistence.Constants;
using InsuranceCalculator.Shared.Result;


namespace InsuranceCalculator.Infrastructure.Persistence.EF.Context;

internal sealed class AppDbContext : DbContext
{
    #region DI objects
    private readonly ILogger<AppDbContext> _logger;
    #endregion

    #region Ctor
    public AppDbContext
        (
            DbContextOptions<AppDbContext> options,
            ILogger<AppDbContext> logger
        ) : base(options) => _logger = logger;
    #endregion

    #region DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<CoverageDefinition> CoverageDefinitions { get; set; }
    public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
    public DbSet<CoverageItem> CoverageItems { get; set; }
    #endregion

    #region Overrided Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public new async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (!ChangeTracker.HasChanges())
                return Result.Success();

            await base.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            LoggingException(ex);
            return ConstantMessages.SaveChangesFailed;
        }
    }
    #endregion

    #region Loggings
    private void LoggingException(Exception ex)
    {
        switch (ex)
        {
            case DbUpdateConcurrencyException:
                _logger?.LogCritical(ex, "DataBase_UpdateConcurrency_Exception");
                break;
            case DbUpdateException:
                _logger?.LogCritical(ex, "DataBase_Update_Exception");
                break;
            case ValidationException:
                _logger?.LogCritical(ex, "DataBase_Validation_Exception");
                break;
            case SqlException:
                _logger?.LogCritical(ex, "DataBase_SQL_Exception");
                break;
            case ObjectDisposedException:
                _logger?.LogCritical(ex, "DataBase_ContextObjectDisposed_Exception");
                break;
            case OperationCanceledException:
                _logger?.LogCritical(ex, "DataBase_OperationCanceled_Exception");
                break;
            default:
                _logger?.LogCritical(ex, "DataBase_Exception");
                break;
        }
    }
    #endregion
}
