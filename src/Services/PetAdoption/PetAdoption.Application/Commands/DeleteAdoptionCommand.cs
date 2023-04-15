namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeleteAdoptionCommand : IRequest<Result<AdoptionDto>>
{
    public required Guid Id { get; set; }
}
