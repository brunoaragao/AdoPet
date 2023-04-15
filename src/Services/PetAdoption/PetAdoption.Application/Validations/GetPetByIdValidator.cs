namespace AdoPet.Services.PetAdoption.Application.Validations;

public class GetPetByIdValidator : AbstractValidator<GetPetByIdQuery>
{
    public GetPetByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}