namespace Adopty.Application.Results;

public record GetSheltersByPageResult
{
    public required IEnumerable<GetSheltersByPageResultItem> Items { get; init; }
}