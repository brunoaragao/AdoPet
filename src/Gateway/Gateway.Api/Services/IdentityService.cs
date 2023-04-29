namespace Gateway.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _client;

    public IdentityService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Identity");
    }

    public async Task<TokenResponse> LoginAsync(string username, string password)
    {
        var request = new Dictionary<string, string>
        {
            ["client_id"] = "password-flow-client",
            ["grant_type"] = "password",
            ["username"] = username,
            ["password"] = password
        };
        var response = await _client.PostAsync("connect/token", new FormUrlEncodedContent(request));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TokenResponse>(content)!;
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