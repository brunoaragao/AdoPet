using static Duende.IdentityServer.IdentityServerConstants;

namespace Identity.Api;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources
    {
        get
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }
    }

    public static IEnumerable<ApiScope> ApiScopes
    {
        get
        {
            yield return new ApiScope("adopty-api-scope");
            yield return new ApiScope("gateway-api-scope");
        }
    }

    public static IEnumerable<Client> Clients
    {
        get
        {

            yield return new Client
            {
                ClientId = "password-flow-client",
                ClientName = "Password Flow Client",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,

                AllowedScopes =
                {
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    "adopty-api-scope",
                    "gateway-api-scope"
                }
            };
        }
    }
}