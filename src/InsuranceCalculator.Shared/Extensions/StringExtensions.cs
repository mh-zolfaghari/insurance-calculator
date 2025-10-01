namespace InsuranceCalculator.Shared.Extensions;

public static class StringExtensions
{
    public static string ToUnderscoreCase(this string input)
        => string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x)
            ? "_" + x.ToString()
            : x.ToString())).ToLower();
}
