namespace AdoPet.Services.PetAdoption.Application.Validations;

public class GetAdoptionByIdValidator : AbstractValidator<GetAdoptionByIdQuery>
{
    public GetAdoptionByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}