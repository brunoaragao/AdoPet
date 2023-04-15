namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, Result<PetDto>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetPetByIdQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<PetDto>> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();
        var shelter = shelters.SingleOrDefault(s => s.Pets.Any(p => p.Id == request.Id));

        if (shelter is null)
            return new NotFoundError($"Pet with id {request.Id} not found");

        var pet = shelter.Pets.Single(p => p.Id == request.Id);

        return new PetDto
        {
            Id = pet.Id,
            Name = pet.Name,
            Age = pet.Age,
            Size = pet.Size,
            Description = pet.Description,
            Photo = pet.Photo,
            ShelterAddress = shelter.Address,
            ShelterId = shelter.Id,
        };
    }
}