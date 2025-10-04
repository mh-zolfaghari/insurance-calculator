using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest;

public static class InsuranceRequestMessages
{
    public static readonly Error InsuranceRequestNotFound = Error.Validation("not_found_insuranec_request", "Insurance Request not found!");
    public static readonly Error RequiredCoverageDefinationId = Error.Validation("coverage_defination_id_validation", "The field CoverageDefinationId is required.");
    public static readonly Error InvalidCoverageDefinationIdFormat = Error.Validation("coverage_defination_id_validation", "CoverageDefinationId must be a valid Guid value.");
    public static readonly Error RequiredCoverageItemCapital = Error.Validation("coverage_item_capital_validation", "Capital is required.");
    public static readonly Error InvalidCoverageItemCapitalIdFormat = Error.Validation("coverage_item_capital_validation", "Capital must not be less than 1.");
    public static readonly Error RequiredInsuranceRequestTitle = Error.Validation("insurance_request_title_validation", "Title is required.");
    public static readonly Error TooManyInsuranceRequestTitle = Error.Validation("insurance_request_title_validation", "Title must not exceed 150 characters.");
    public static readonly Error RequiredCoverageItem = Error.Validation("insurance_request_coverage_items_validation", "CoverageItems collection is required.");
    public static readonly Error LeastOneCoverageItem = Error.Validation("insurance_request_coverage_items_validation", "At least one CoverageItem must be provided.");
}
