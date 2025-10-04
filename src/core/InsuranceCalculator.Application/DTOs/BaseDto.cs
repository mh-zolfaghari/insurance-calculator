namespace InsuranceCalculator.Application.DTOs;

public abstract record BaseDto<TKey> where TKey : struct
{
    public required TKey Id { get; init; }
}
