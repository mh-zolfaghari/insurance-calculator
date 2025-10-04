using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Application.Helpers;

internal static class CoverageItemHelpers
{
    internal static CoverageItemDto? ToDto(this CoverageItem model, BaseId? id = default)
    {
        if (model is not null)
            return new()
            {
                Id = model.Id,
                Capital = model.Capital,
                Premium = model.Premium,
                CoverageDefination = model.CoverageDefinition.ToDto(model.CoverageDefinitionId)
            };
        if (id is not null)
            return new()
            {
                Id = id.Value
            };
        return null;
    }
}
