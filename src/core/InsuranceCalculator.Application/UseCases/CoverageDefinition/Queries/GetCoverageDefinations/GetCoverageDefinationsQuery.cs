using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Shared.Abstraction.Queries;
using InsuranceCalculator.Shared.Abstraction.Security;

namespace InsuranceCalculator.Application.UseCases.CoverageDefinition.Queries.GetCoverageDefinations;

public record GetCoverageDefinationsQuery : IQueryRequest<IEnumerable<CoverageDefinationDto>>, IAnonymousRequest
{
    public string? Name { get; set; } = default;
}
