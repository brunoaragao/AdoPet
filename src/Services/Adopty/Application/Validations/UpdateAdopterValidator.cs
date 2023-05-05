namespace Adopty.Application.Validations;

public class UpdateAdopterValidator : AbstractValidator<UpdateAdopter>
{
    public UpdateAdopterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}