namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeletePetCommand : IRequest<Result<PetDto>>
{
    public required Guid Id { get; set; }
}
