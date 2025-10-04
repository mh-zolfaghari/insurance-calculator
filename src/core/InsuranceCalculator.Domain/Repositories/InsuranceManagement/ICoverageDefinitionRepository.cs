using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Repositories.InsuranceManagement;

public interface ICoverageDefinitionRepository
{
    Task<IReadOnlyList<CoverageDefinition>> GetByIdsAsync(IEnumerable<BaseId> ids, CancellationToken cancellationToken);
    Task<IReadOnlyList<CoverageDefinition>> GetAllAsync(string? name, CancellationToken cancellationToken);
}
