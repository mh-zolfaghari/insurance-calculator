using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.UseCases.InsuranceRequest.Queries.GetCurrentUserInsuranceRequests;
using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.RequestModels;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Application.Helpers;

internal static class InsuranceRequestHelpers
{
    internal static InsuranceRequestDto? ToDto(this InsuranceRequest? model, BaseId? id = default)
    {
        if (model is not null)
            return new()
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                TotalCapital = model.TotalCapital(),
                TotalPremium = model.TotalPremium(),
                User = model.User.ToDto(model.UserId),
                CoverageItems = model.Items?.Select(i => i.ToDto(id)!)
            };
        if (id is not null)
            return new()
            {
                Id = id.Value
            };
        return null;
    }

    internal static UserInsuranceRequestModel ToRequestModel(this GetCurrentUserInsuranceRequestsQuery command, BaseId userId)
        => new(userId, command.Page, command.PageSize);
}
