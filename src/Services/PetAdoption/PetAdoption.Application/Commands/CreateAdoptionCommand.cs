namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateAdoptionCommand : IRequest<Result<AdoptionDto>>
{
    public required Guid PetId { get; set; }
    public required Guid AdopterId { get; set; }
}
