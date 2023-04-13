namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdopterByIdQueryHandler : IRequestHandler<GetAdopterByIdQuery, Result<AdopterDto>>
{
    private readonly IAdopterRepository _adopterRepository;

    public GetAdopterByIdQueryHandler(IAdopterRepository adopterRepository)
    {
        _adopterRepository = adopterRepository;
    }

    public async Task<Result<AdopterDto>> Handle(GetAdopterByIdQuery request, CancellationToken cancellationToken)
    {
        var adopter = await _adopterRepository.GetByIdAsync(request.Id);
        if (adopter is null)
        {
            return new NotFoundError($"Adopter with id {request.Id} not found");
        }

        return new AdopterDto
        {
            Id = adopter.Id,
            Name = adopter.Name,
            Email = adopter.Email,
            Phone = adopter.Phone,
            Address = adopter.Address,
            Photo = adopter.Photo,
            Description = adopter.Description
        };
    }
}