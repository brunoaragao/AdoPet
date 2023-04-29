namespace Identity.Contracts;

public record RegisterUser
{
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}