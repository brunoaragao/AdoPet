namespace Swashbuckle.AspNetCore.SwaggerGen;

public static class SwaggerGenOptionsExtensions
{
    public static void AddPasswordSecurityDefinition(this SwaggerGenOptions options, IConfiguration configuration)
    {
        options.AddSecurityDefinition("api-gateway-swagger-ui-client", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                Password = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri(configuration["Swagger:OAuth2:TokenUrl"]!)
                }
            }
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "api-gateway-swagger-ui-client"
                    }
                },
                Array.Empty<string>()
            }
        });
    }
}