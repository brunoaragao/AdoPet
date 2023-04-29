namespace Adopty.Application.Validations;

public class CreateAdopterValidator : AbstractValidator<CreateAdopter>
{
    public CreateAdopterValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}