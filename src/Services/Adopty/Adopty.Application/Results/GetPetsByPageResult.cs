namespace Adopty.Application.Results;

public record GetPetsByPageResult
{
    public required IEnumerable<GetPetsByPageResultItem> Items { get; init; }
}