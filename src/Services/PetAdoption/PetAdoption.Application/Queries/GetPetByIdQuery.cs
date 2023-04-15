namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetPetByIdQuery : IRequest<Result<PetDto>>
{
    public required Guid Id { get; set; }
}