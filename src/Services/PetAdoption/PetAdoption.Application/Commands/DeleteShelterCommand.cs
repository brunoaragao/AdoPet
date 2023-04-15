namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeleteShelterCommand : IRequest<Result<ShelterDto>>
{
    public required Guid Id { get; set; }
}
