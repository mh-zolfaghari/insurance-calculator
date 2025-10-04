using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Infrastructure.Persistence.EF.Context;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Repositories;

internal class CoverageDefinitionRepository(AppDbContext dbContext) : ICoverageDefinitionRepository
{
    public async Task<IReadOnlyList<CoverageDefinition>> GetAllAsync(string? name, CancellationToken cancellationToken)
        => await dbContext.CoverageDefinitions
            .AsNoTracking()
            .Where(string.IsNullOrWhiteSpace(name) ? _ => true : cd => cd.Name.Contains(name))
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<CoverageDefinition>> GetByIdsAsync(IEnumerable<BaseId> ids, CancellationToken cancellationToken)
        => (await dbContext.CoverageDefinitions
            .AsNoTracking()
            .Where(cd => ids.Contains(cd.Id))
            .ToListAsync(cancellationToken)) ?? [];
}
