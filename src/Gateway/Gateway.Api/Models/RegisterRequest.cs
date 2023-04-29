namespace Gateway.Api.Models;

public record RegisterRequest
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}