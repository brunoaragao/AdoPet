namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdopterByIdQuery : IRequest<Result<AdopterDto>>
{
    public required Guid Id { get; set; }
}