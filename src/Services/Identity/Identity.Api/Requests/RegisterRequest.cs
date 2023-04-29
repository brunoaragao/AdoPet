namespace Identity.Requests;

public record RegisterRequest
{
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required IEnumerable<string> Roles { get; init; }
    public required string? FullName { get; init; }
}