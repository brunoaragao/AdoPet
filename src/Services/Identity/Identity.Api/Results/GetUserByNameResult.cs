namespace Identity.Api.Results;

public record GetUserByNameResult
{
    public required Guid Id { get; init; }
    public required string UserName { get; init; }
    public required string Email { get; init; }
}