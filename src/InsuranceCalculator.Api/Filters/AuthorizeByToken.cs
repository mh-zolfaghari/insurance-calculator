namespace InsuranceCalculator.Api.Filters;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
internal sealed class AuthorizeByTokenAttribute : Attribute
{
}
