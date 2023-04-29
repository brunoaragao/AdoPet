namespace Adopty.Application.Results;

public record GetAdoptionsByPageResult
{
    public required IEnumerable<GetAdoptionsByPageResultItem> Items { get; init; }
}