namespace AdoPet.Services.PetAdoption.Application.Validations;

public class DeleteShelterValidator : AbstractValidator<DeleteShelterCommand>
{
    public DeleteShelterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}