namespace Adopty.Application.Responses;

public record GetAdoptersByPageResult(IEnumerable<GetAdoptersByPageResultItem> Items);