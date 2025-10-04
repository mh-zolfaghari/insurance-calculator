namespace InsuranceCalculator.Shared.Abstraction.Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }
}
