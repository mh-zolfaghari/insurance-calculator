using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class CoverageDefinitionNameTooLongException : UserManagementException
{
    public CoverageDefinitionNameTooLongException() : base("The CoverageDefinitionName length should not exceed 150 characters.")
    {
    }
}
