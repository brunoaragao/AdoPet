namespace Swashbuckle.AspNetCore.SwaggerGen;

public static class SwaggerGenOptionsExtensions
{
    public static void AddPasswordSecurityDefinition(this SwaggerGenOptions options, IConfiguration configuration)
    {
        options.AddSecurityDefinition("password-flow-client", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                Password = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri($"{configuration["Services:Identity:Url"]}/connect/token")
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
                        Id = "password-flow-client"
                    }
                },
                Array.Empty<string>()
            }
        });
    }
}