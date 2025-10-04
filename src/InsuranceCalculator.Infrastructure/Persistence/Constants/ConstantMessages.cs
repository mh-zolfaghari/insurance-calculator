using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Infrastructure.Persistence.Constants;

public static class ConstantMessages
{
    public static readonly Error SaveChangesFailed = Error.Failure("SaveChangesFailed", "Database operation failed :(");
}
