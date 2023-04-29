namespace Adopty.Application.Validations;

public class GetAdoptersByPageValidator : AbstractValidator<GetAdoptersByPage>
{
    public GetAdoptersByPageValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
    }
}