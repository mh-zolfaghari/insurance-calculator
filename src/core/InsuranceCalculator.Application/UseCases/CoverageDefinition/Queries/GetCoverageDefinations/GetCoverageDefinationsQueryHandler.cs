using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.Helpers;
using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Shared.Abstraction.Queries;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.CoverageDefinition.Queries.GetCoverageDefinations;

public class GetCoverageDefinationsQueryHandler(ICoverageDefinitionRepository coverageDefinationRepository) : IQueryHandler<GetCoverageDefinationsQuery, IEnumerable<CoverageDefinationDto>>
{
    private readonly ICoverageDefinitionRepository _coverageDefinationRepository = coverageDefinationRepository;

    public async Task<Result<IEnumerable<CoverageDefinationDto>>> Handle(GetCoverageDefinationsQuery request, CancellationToken cancellationToken)
    {
        var result = await _coverageDefinationRepository.GetAllAsync(request.Name, cancellationToken);
        return Result.Success<IEnumerable<CoverageDefinationDto>>(result.Select(x => x.ToDto()!));
    }
}
