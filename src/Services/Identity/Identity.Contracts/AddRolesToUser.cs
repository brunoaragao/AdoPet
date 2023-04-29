namespace Identity.Contracts;

public record AddRolesToUser
{
    public required string UserName { get; init; }
    public required IEnumerable<string> Roles { get; init; }
}