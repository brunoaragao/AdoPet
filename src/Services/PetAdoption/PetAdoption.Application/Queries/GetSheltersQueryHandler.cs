namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetSheltersQueryHandler : IRequestHandler<GetSheltersQuery, Result<IEnumerable<ShelterDto>>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetSheltersQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<IEnumerable<ShelterDto>>> Handle(GetSheltersQuery request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();

        var dtos = shelters.Select(shelter => new ShelterDto
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address
        });

        return Result.Ok(dtos);
    }
}