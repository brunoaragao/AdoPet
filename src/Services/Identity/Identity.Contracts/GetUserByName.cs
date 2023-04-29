namespace Identity.Contracts;

public record GetUserByName
{
    public required string UserName { get; init; }
}