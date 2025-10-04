using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories
{
    public interface IUserFactory
    {
        User Create
            (
                BaseId id,
                Guid token,
                string firstName,
                string lastName
            );
    }
}
