namespace Gateway.Api.Services;

public interface IIdentityService
{
    Task<string> LoginAsync(string username, string password);
    Task RegisterUserAsync(string username, string email, string password, IEnumerable<string> roles, string? fullName = null);
}