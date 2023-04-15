namespace AdoPet.Services.PetAdoption.Application.Validations;

public class DeleteAdoptionValidator : AbstractValidator<DeleteAdoptionCommand>
{
    public DeleteAdoptionValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}