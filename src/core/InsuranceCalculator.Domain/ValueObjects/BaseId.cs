using InsuranceCalculator.Domain.Exceptions;

namespace InsuranceCalculator.Domain.ValueObjects;

public readonly record struct BaseId
{
    public Guid Value { get; private init; }

    public static BaseId NewId() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public BaseId(Guid value)
    {
        if (value == Guid.Empty)
            throw new BaseIdEmptyException();

        Value = value;
    }

    public static implicit operator Guid(BaseId baseId) => baseId.Value;
    public static implicit operator BaseId(Guid value) => new(value);
}
