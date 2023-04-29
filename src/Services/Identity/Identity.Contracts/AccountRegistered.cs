namespace Identity.Contracts;

public record AccountRegistered
{
    public required Guid UserId { get; init; }
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required IEnumerable<string> Roles { get; init; }
    public required IEnumerable<KeyValuePair<string, string>> Claims { get; init; }
}