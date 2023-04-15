namespace AdoPet.Services.PetAdoption.Application.Validations;

public class DeletePetValidator : AbstractValidator<DeletePetCommand>
{
    public DeletePetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}