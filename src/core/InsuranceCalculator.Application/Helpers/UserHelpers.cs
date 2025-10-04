using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Application.Helpers;

internal static class UserHelpers
{
    internal static UserDto? ToDto(this User? model, BaseId? id = default)
    {
        if (model is not null)
            return new()
            {
                Id = model.Id,
                Token = model.Token,
                FullName = $"{model.FirstName} {model.LastName}",
            };
        if (id is not null)
            return new()
            {
                Id = id.Value
            };
        return null;
    }

    internal static UserInsuranceRequestsDto ToUserInsuranceRequestsDto(this ICurrentUserContext model, IReadOnlyList<InsuranceRequest>? insuranceRequests)
        => new()
        {
            Id = model.UserId!.Value,
            FullName = $"{model.FirstName} {model.LastName}",
            InsuranceRequests = insuranceRequests?.Select(ir => ir.ToDto()!) ?? []
        };
}
