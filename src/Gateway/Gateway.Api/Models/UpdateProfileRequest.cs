namespace Gateway.Api.Models;

public record UpdateProfileRequest
{
    public required string? Photo { get; init; }
    public required string? Name { get; init; }
    public required string? Phone { get; init; }
    public required string? City { get; init; }
    public required string? About { get; init; }
}