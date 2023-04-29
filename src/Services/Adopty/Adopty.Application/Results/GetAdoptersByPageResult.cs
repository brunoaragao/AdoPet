namespace Adopty.Application.Results;

public record GetAdoptersByPageResult
{
    public required IEnumerable<GetAdoptersByPageResultItem> Items { get; init; }
}