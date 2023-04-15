namespace AdoPet.Services.PetAdoption.Application.Commands;

public class UpdateShelterCommand : IRequest<Result<ShelterDto>>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
}
