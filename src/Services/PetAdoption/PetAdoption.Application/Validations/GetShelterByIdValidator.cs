namespace AdoPet.Services.PetAdoption.Application.Validations;

public class GetShelterByIdValidator : AbstractValidator<GetShelterByIdQuery>
{
    public GetShelterByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}