namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdoptionsQueryHandler : IRequestHandler<GetAdoptionsQuery, Result<IEnumerable<AdoptionDto>>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetAdoptionsQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<IEnumerable<AdoptionDto>>> Handle(GetAdoptionsQuery request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();
        var adoptions = shelters.SelectMany(s => s.Adoptions);

        var dtos = adoptions.Select(adoption => new AdoptionDto
        {
            Id = adoption.Id,
            PetId = adoption.PetId,
            AdopterId = adoption.AdopterId
        });

        return Result.Ok(dtos);
    }
}