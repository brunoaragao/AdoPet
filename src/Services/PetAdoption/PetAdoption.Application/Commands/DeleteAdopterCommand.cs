namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeleteAdopterCommand : IRequest<Result<AdopterDto>>
{
    public required Guid Id { get; set; }
}