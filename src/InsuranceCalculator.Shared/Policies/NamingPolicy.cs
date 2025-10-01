using InsuranceCalculator.Shared.Extensions;

namespace InsuranceCalculator.Shared.Policies;

public class NamingPolicy
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToUnderscoreCase();
    }
}
