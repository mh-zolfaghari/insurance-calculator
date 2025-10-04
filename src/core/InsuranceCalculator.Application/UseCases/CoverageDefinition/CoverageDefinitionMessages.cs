using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.CoverageDefinition;

public static class CoverageDefinitionMessages
{
    public static readonly Error NotFound = Error.Validation("not_found_coverage_definition", "Coverage Definition not found!");
    public static readonly Error InvalidName = Error.Validation("name_validation", "Maximum length for Coverage Definition Name is 150.");
    public static readonly Error InvalidId = Error.Validation("id_validation", "Invalid Coverage Definition Id.");
    public static Error InvalidIds(IEnumerable<Guid> invalidIds) => Error.Validation("ids_validation", $"Invalid Coverage Defination Ids : [ {string.Join(", ", invalidIds)} ]!");
    public static Error InvalidCapitalIds(IEnumerable<Guid> invalidCapitalIds) => Error.Validation("capitals_validation", $"Invalid Coverage Item Capital value Ids : [ {string.Join(", ", invalidCapitalIds)} ]!");
}
