using static Duende.IdentityServer.IdentityServerConstants;

namespace Identity.Api;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources
    {
        get => Enumerable.Empty<IdentityResource>();
    }

    public static IEnumerable<ApiScope> ApiScopes
    {
        get
        {
            yield return new ApiScope("api-gateway-scope");
        }
    }

    public static IEnumerable<Client> Clients
    {
        get
        {
            yield return new Client
            {
                ClientId = "api-gateway-client",
                ClientName = "API Gateway Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,
                AllowedScopes = { "api-gateway-scope" }
            };
            yield return new Client
            {
                ClientId = "api-gateway-swagger-ui-client",
                ClientName = "API Gateway Swagger UI Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,
                AllowedScopes = { "api-gateway-scope" }
            };
        }
    }
}