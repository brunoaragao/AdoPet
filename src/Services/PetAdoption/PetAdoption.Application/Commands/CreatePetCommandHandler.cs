namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Result<PetDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePetCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PetDto>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var shelter = await _shelterRepository.GetByIdAsync(request.ShelterId);

        if (shelter is null)
            return new ConflictError($"Shelter with id {request.ShelterId} does not exist");

        var pet = new Pet(request.Name, request.Age, request.Size, request.Description, request.Photo);
        shelter.AddPet(pet);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new PetDto
        {
            Id = pet.Id,
            Name = pet.Name,
            Age = pet.Age,
            Size = pet.Size,
            Description = pet.Description,
            Photo = pet.Photo,
            ShelterAddress = shelter.Address,
            ShelterId = shelter.Id
        };
    }
}
