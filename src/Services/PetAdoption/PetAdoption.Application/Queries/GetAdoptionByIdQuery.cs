namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdoptionByIdQuery : IRequest<Result<AdoptionDto>>
{
    public Guid Id { get; set; }
}