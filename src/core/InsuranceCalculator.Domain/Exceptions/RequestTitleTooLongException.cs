using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class RequestTitleTooLongException : InsuranceManagementException
{
    public RequestTitleTooLongException() : base("The RequestTitle length should not exceed 150 characters.")
    {
    }
}
