using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class BaseIdEmptyException : PrimitiveException
{
    public BaseIdEmptyException() : base("Base Id can not be empty.")
    {
    }
}
