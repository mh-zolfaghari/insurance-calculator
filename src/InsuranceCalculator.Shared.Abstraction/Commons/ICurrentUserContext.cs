namespace InsuranceCalculator.Shared.Abstraction.Commons;

public interface ICurrentUserContext : IClientToken
{
    Guid? UserId { get; }
    string? FirstName { get; }
    string? LastName { get; }

    void Initialize(Guid userId, string? firstName, string? lastName);
}
