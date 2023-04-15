namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateShelterCommand : IRequest<Result<ShelterDto>>
{
    public required string Name { get; set; }
    public required string Address { get; set; }
}
