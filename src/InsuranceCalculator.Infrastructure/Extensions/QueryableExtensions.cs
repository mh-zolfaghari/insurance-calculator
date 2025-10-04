using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Infrastructure.Extensions;

internal static class QueryableExtensions
{
    internal static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IPaginateable pagination)
        where T : class
    {
        var pageNumber = pagination?.Page ?? 1;
        var pageSize = pagination?.PageSize ?? 10;

        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
