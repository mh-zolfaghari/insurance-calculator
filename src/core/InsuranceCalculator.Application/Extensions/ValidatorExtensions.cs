using InsuranceCalculator.Application.Commons;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Application.Extensions;

internal static class ValidatorExtensions
{
    internal static void PaginateValidator<T>(this AbstractValidator<T> validator)
        where T : class, IPaginateable, new()
    {
        validator
            .RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1).WithMessage(CommonMessages.Pagination.InvalidPage.Message);

        validator
            .RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100).WithMessage(CommonMessages.Pagination.InvalidPageSize.Message);
    }
}
