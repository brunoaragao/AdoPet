namespace Adopty.Application.Requests;

public record GetAdoptionsByPage(
    int PageNumber,
    int PageSize);