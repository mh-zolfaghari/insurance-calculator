using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Application.Helpers;

internal static class CoverageDefinationHelpers
{
    internal static CoverageDefinationDto? ToDto(this CoverageDefinition? model, BaseId? id = default)
    {
        if (model is not null)
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Minimum = model.Minimum,
                Maximum = model.Maximum,
                PremiumRate = model.PremiumRate
            };
        if (id is not null)
            return new()
            {
                Id = id.Value
            };
        return null;
    }
}
