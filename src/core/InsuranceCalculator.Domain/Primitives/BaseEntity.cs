using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Primitives;

public abstract class BaseEntity
{
    public BaseId Id { get; protected set; } = BaseId.NewId();
}
