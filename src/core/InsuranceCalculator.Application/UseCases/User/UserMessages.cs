using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.User
{
    public static class UserMessages
    {
        public static readonly Error NotFound = Error.Validation("not_found_user", "User not found!");
        public static readonly Error InvalidId = Error.Validation("id_validation", "Invalid User Id.");
    }
}
