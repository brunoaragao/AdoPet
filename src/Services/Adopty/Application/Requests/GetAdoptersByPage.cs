namespace Adopty.Application.Requests;

public record GetAdoptersByPage(
    int PageNumber,
    int PageSize);