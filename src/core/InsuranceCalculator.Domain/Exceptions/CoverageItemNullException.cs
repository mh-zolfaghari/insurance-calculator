using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class CoverageItemNullException : InsuranceManagementException
{
    public CoverageItemNullException() : base("Coverage item can't be null")
    {
    }
}
