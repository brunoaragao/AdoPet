namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdoptersQueryHandler : IRequestHandler<GetAdoptersQuery, Result<IEnumerable<AdopterDto>>>
{
    private readonly IAdopterRepository _adopterRepository;

    public GetAdoptersQueryHandler(IAdopterRepository adopterRepository)
    {
        _adopterRepository = adopterRepository;
    }

    public async Task<Result<IEnumerable<AdopterDto>>> Handle(GetAdoptersQuery request, CancellationToken cancellationToken)
    {
        var adopters = await _adopterRepository.GetAllAsync();

        var dtos = adopters.Select(adopter => new AdopterDto
        {
            Id = adopter.Id,
            Name = adopter.Name,
            Email = adopter.Email,
            Phone = adopter.Phone,
            Address = adopter.Address,
            Photo = adopter.Photo,
            Description = adopter.Description
        });

        return Result.Ok(dtos);
    }
}