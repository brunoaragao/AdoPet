namespace Gateway.Api.Models;

public record LoginRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}