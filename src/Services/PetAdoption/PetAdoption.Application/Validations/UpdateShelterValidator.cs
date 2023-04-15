namespace AdoPet.Services.PetAdoption.Application.Validations;

public class UpdateShelterValidator : AbstractValidator<UpdateShelterCommand>
{
    public UpdateShelterValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
    }
}