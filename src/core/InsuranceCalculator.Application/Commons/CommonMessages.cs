using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.Commons;

internal static class CommonMessages
{
    internal static class Pagination
    {
        internal static readonly Error InvalidPage = Error.Failure("pagination_validation", "Page must not be less than 1.");
        internal static readonly Error InvalidPageSize = Error.Failure("pagination_validation", "PageSize must not be less than 1.");
    }
}
