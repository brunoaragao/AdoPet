namespace Adopty.Application.Validations;

public class UpdateAdoptionValidator : AbstractValidator<UpdateAdoption>
{
    public UpdateAdoptionValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.AdopterId).NotEmpty();
        RuleFor(x => x.PetId).NotEmpty();
    }
}