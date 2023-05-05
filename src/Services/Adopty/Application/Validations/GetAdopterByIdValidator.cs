namespace Adopty.Application.Validations;

public class GetAdopterByIdValidator : AbstractValidator<GetAdopterById>
{
    public GetAdopterByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}