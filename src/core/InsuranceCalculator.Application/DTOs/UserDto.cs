namespace InsuranceCalculator.Application.DTOs;

public record UserDto : BaseDto<Guid>
{
    public Guid? Token { get; init; }
    public string? FullName { get; init; }
}
