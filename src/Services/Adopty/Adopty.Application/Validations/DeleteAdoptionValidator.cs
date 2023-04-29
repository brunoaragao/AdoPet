namespace Adopty.Application.Validations;

public class DeleteAdoptionValidator : AbstractValidator<DeleteAdoption>
{
    public DeleteAdoptionValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}