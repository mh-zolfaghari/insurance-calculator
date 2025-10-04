using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Api.Filters
{
    public class AuthorizeByTokenOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorizeByToken = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeByTokenAttribute>().Any() 
                || context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AuthorizeByTokenAttribute>().Any() == true;

            if (!hasAuthorizeByToken)
                return;

            operation.Parameters ??= new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = nameof(IClientToken.Token),
                In = ParameterLocation.Header,
                Required = true,
                Description = "Access token (e.g., A6E71FAF-AB39-492E-B227-0DA80EA49232)",
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
