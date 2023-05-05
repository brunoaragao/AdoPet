namespace Gateway.Api.Services;

public class AdoptyService : IAdoptyService
{
    private readonly HttpClient _client;
    private static readonly int s_pageSize = 10;

    public AdoptyService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Adopty");
    }

    public async Task CreateAdopterAsync(string? photo, string fullName, string? phone, string? city, string? about)
    {
        var request = new
        {
            Photo = photo,
            FullName = fullName,
            Phone = phone,
            City = city,
            About = about
        };
        var response = await _client.PostAsJsonAsync("api/v1/adopter", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<GetPetsByPageResponse> GetPetsByPageAsync(int pageNumber)
    {
        var response = await _client.GetAsync($"api/v1/pets?pageNumber={pageNumber}&pageSize={s_pageSize}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GetPetsByPageResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task UpdateAdopterByUserIdAsync(Guid userId, string? photo, string? name, string? phone, string? city, string? about)
    {
        var request = new
        {
            UserId = userId,
            Photo = photo,
            Name = name,
            Phone = phone,
            City = city,
            About = about
        };
        var response = await _client.PostAsJsonAsync("api/v1/Adopters/UpdateAdopterByUserId", request);
        response.EnsureSuccessStatusCode();
    }
}