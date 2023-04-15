namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateAdoptionCommandHandler : IRequestHandler<CreateAdoptionCommand, Result<AdoptionDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IAdopterRepository _adopterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdoptionCommandHandler(IShelterRepository shelterRepository, IAdopterRepository adopterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _adopterRepository = adopterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AdoptionDto>> Handle(CreateAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adopter = await _adopterRepository.GetByIdAsync(request.AdopterId);

        if(adopter is null)
            return new ConflictError($"Adopter with id {request.AdopterId} does not exist");

        var shelters = await _shelterRepository.GetAllAsync();

        var shelter = shelters.SingleOrDefault(s =>
            s.Pets.Any(p => p.Id == request.PetId));

        if (shelter is null)
            return new ConflictError($"Shelter with pet id {request.PetId} does not exist");

        if (shelter.Adoptions.Any(a => a.PetId == request.PetId))
            return new ConflictError($"Pet with id {request.PetId} is already adopted");

        var pet = shelter.Pets.Single(p => p.Id == request.PetId);
        var adoption = new Adoption(pet.Id, request.AdopterId);
        shelter.AddAdoption(adoption);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new AdoptionDto
        {
            Id = adoption.Id,
            PetId = pet.Id,
            AdopterId = adoption.AdopterId
        };
    }
}