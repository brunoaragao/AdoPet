namespace Adopty.Application.Validations;

public class DeleteAdopterValidator : AbstractValidator<DeleteAdopter>
{
    public DeleteAdopterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}