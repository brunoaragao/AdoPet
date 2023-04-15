namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetAdoptionByIdQueryHandler : IRequestHandler<GetAdoptionByIdQuery, Result<AdoptionDto>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetAdoptionByIdQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<AdoptionDto>> Handle(GetAdoptionByIdQuery request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();
        var shelter = shelters.SingleOrDefault(s => s.Adoptions.Any(a => a.Id == request.Id));

        if (shelter is null)
            return new NotFoundError($"Adoption with id {request.Id} not found");

        var adoption = shelter.Adoptions.Single(a => a.Id == request.Id);

        return new AdoptionDto
        {
            Id = adoption.Id,
            PetId = adoption.PetId,
            AdopterId = adoption.AdopterId
        };
    }
}