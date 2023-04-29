namespace Identity.Contracts;

public record AddClaimsToUser
{
    public required string UserName { get; init; }
    public required IEnumerable<Claim> Claims { get; init; }
}