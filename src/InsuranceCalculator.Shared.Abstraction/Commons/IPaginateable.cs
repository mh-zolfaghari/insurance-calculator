namespace InsuranceCalculator.Shared.Abstraction.Commons;

public interface IPaginateable
{
    int? Page { get; init; }
    int? PageSize { get; init; }
}
