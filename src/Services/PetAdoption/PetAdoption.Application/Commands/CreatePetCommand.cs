namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreatePetCommand : IRequest<Result<PetDto>>
{
    public required string Name { get; set; }
    public required string Age { get; set; }
    public required string Size { get; set; }
    public required string Description { get; set; }
    public required string Photo { get; set; }
    public required Guid ShelterId { get; set; }
}