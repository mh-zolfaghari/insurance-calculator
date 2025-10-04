using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class CoverageDefinitionNameNullOrEmptyException : UserManagementException
{
    public CoverageDefinitionNameNullOrEmptyException() : base("CoverageDefinitionName can't be Null or Empty value.")
    {
    }
}
