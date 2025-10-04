using InsuranceCalculator.Application.UseCases.CoverageDefinition;
using InsuranceCalculator.Domain.Factories;
using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Commands;
using InsuranceCalculator.Shared.Abstraction.Commons;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Commands.CreateInsuranceRequest;

public class CreateInsuranceRequestCommandHandler
    (
        ICoverageDefinitionRepository coverageDefinitionRepository,
        IInsuranceRequestRepository insuranceRequestRepository,
        ICurrentUserContext currentUserContext,
        IInsuranceRequestFactory insuranceRequestFactory,
        ICoverageItemFactory coverageItemFactory
    ) : ICommandHandler<CreateInsuranceRequestCommand>
{
    private readonly ICoverageDefinitionRepository _coverageDefinitionRepository = coverageDefinitionRepository;
    private readonly IInsuranceRequestRepository _insuranceRequestRepository = insuranceRequestRepository;
    private readonly ICurrentUserContext _currentUserContext = currentUserContext;
    private readonly IInsuranceRequestFactory _insuranceRequestFactory = insuranceRequestFactory;
    private readonly ICoverageItemFactory _coverageItemFactory = coverageItemFactory;

    public async Task<Result> Handle(CreateInsuranceRequestCommand request, CancellationToken cancellationToken)
    {
        var definationIds = request.CoverageItems.Select(x => new BaseId(x.CoverageDefinationId)) ?? [];
        var foundedCoverageDefinations = await _coverageDefinitionRepository.GetByIdsAsync(definationIds, cancellationToken);
        var notFoundedIds = definationIds.Except(foundedCoverageDefinations.Select(x => x.Id)).Select(x => x.Value);

        if (notFoundedIds?.Any() == true)
            return Result.Failure(CoverageDefinitionMessages.InvalidIds(notFoundedIds));

        var newInsuranceRequest = _insuranceRequestFactory.Create
            (
                BaseId.NewId(),
                _currentUserContext.UserId!.Value,
                request.Title,
                DateTime.Now
            );

        var invalidCapitalItems = new List<Guid>();
        foreach (var item in request.CoverageItems)
        {
            var coverageDefination = foundedCoverageDefinations.First(x => x.Id == new BaseId(item.CoverageDefinationId));
            if (item.Capital < coverageDefination.Minimum || item.Capital > coverageDefination.Maximum)
                invalidCapitalItems.Add(item.CoverageDefinationId);
            else
            {
                var coverageItem = _coverageItemFactory.Create
                    (
                        BaseId.NewId(),
                        coverageDefination.Id,
                        newInsuranceRequest.Id,
                        item.Capital,
                        coverageDefination.CalculatePremium(item.Capital)
                    );

                newInsuranceRequest.AddCoverageItem(coverageItem);
            }
        }

        if (invalidCapitalItems.Any())
            return Result.Failure(CoverageDefinitionMessages.InvalidCapitalIds(invalidCapitalItems));

        return await _insuranceRequestRepository.AddAsync(newInsuranceRequest, cancellationToken);
    }
}
