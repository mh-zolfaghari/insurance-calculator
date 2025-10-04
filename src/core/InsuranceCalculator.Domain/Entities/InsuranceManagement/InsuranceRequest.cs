using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.Exceptions;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Domain;

namespace InsuranceCalculator.Domain.Entities.InsuranceManagement;

public class InsuranceRequest : AggregateRoot<BaseId>
{
    private readonly List<CoverageItem> _items = new();

    public BaseId UserId { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User User { get; private set; }
    public IReadOnlyCollection<CoverageItem> Items => _items.AsReadOnly();

    private InsuranceRequest() { }

    internal InsuranceRequest
        (
            BaseId id,
            BaseId userId,
            string title,
            DateTime createdAt
        )
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new RequestTitleNullOrEmptyException();

        if (title.Length > 150)
            throw new RequestTitleTooLongException();

        Id = id;
        UserId = userId;
        Title = title;
        CreatedAt = createdAt;
    }

    public void AddCoverageItem(CoverageItem item)
    {
        if (item is null)
            throw new CoverageItemNullException();

        if (_items.Any(i => i.CoverageDefinitionId == item.CoverageDefinitionId))
            throw new DuplicateCoverageItemException();

        if (_items.Count >= 3)
            throw new InvalidCoverageItemCountException();

        _items.Add(item);
    }

    public decimal TotalCapital() => _items.Sum(i => i.Capital);
    public decimal TotalPremium() => _items.Sum(i => i.Premium.Amount);
}
