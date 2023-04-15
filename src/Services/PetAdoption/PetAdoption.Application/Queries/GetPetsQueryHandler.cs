namespace AdoPet.Services.PetAdoption.Application.Queries;

public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, Result<IEnumerable<PetDto>>>
{
    private readonly IShelterRepository _shelterRepository;

    public GetPetsQueryHandler(IShelterRepository shelterRepository)
    {
        _shelterRepository = shelterRepository;
    }

    public async Task<Result<IEnumerable<PetDto>>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();

        var dtos = from shelter in shelters
                   from pet in shelter.Pets
                   select new PetDto
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

        return Result.Ok(dtos);
    }
}