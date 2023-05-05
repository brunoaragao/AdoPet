namespace Adopty.Application.Validations;

public class GetAdoptionsByPageValidator : AbstractValidator<GetAdoptionsByPage>
{
    public GetAdoptionsByPageValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}