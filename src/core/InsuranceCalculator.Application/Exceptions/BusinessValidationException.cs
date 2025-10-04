using InsuranceCalculator.Application.Commons;

namespace InsuranceCalculator.Application.Exceptions
{
    public sealed class BusinessValidationException(List<ValidationError> errors) : Exception
    {
        public readonly List<ValidationError> Errors = errors;
    }
}
