using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class DuplicateCoverageItemException : InsuranceManagementException
{
    public DuplicateCoverageItemException() : base("Duplicate coverage definitions are not allowed in a request")
    {
    }
}
