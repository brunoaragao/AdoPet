namespace Adopty.Application.Responses;

public record GetAdoptionsByPageResult(IEnumerable<GetAdoptionsByPageResultItem> Items);