namespace Adopty.Application.Validations;

public class DeleteShelterValidator : AbstractValidator<DeleteShelter>
{
    public DeleteShelterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}