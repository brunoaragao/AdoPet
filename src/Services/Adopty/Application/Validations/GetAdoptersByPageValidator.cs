namespace Adopty.Application.Validations;

public class GetAdoptersByPageValidator : AbstractValidator<GetAdoptersByPage>
{
    public GetAdoptersByPageValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}