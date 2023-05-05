namespace Adopty.Application.Validations;

public class DeletePetValidator : AbstractValidator<DeletePet>
{
    public DeletePetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}