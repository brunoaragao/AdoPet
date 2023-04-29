namespace Gateway.Api.Services;

public interface IAdoptyService
{
    Task CreateAdopterAsync(string? photo, string fullName, string? phone, string? city, string? about);
    Task<GetPetsByPageResponse> GetPetsByPageAsync(int page);
    Task UpdateAdopterByUserIdAsync(Guid userId, string? photo, string? name, string? phone, string? city, string? about);
}