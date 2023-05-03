global using IdentityModel.Client;

namespace Gateway.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public IdentityService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _client = httpClientFactory.CreateClient("Identity");
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var discovery = await _client.GetDiscoveryDocumentAsync(_configuration["Services:Identity:Url"]);
        var response = await _client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discovery.TokenEndpoint,

            ClientId = "api-gateway-client",

            UserName = username,
            Password = password
        });
        return response.AccessToken!;
    }

    public async Task RegisterUserAsync(string username, string email, string password, IEnumerable<string> roles, string? fullName = null)
    {
        var request = new
        {
            Username = username,
            Email = email,
            Password = password,
            Roles = roles,
            FullName = fullName
        };
        var response = await _client.PostAsJsonAsync("connect/register", request);
        response.EnsureSuccessStatusCode();
    }
}