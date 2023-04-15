namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetShelterByIdQuery : IRequest<Result<ShelterDto>>
{
    public required Guid Id { get; set; }
}