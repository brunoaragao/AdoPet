namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetShelterByIdQueryHandler : IRequestHandler<GetShelterByIdQuery, Result<ShelterDto>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetShelterByIdQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<ShelterDto>> Handle(GetShelterByIdQuery request, CancellationToken cancellationToken)
    {
        var shelter = await _shelterRepository.GetByIdAsync(request.Id);

        if (shelter is null)
            return new NotFoundError($"Shelter with id {request.Id} not found");

        return new ShelterDto
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address
        };
    }
}