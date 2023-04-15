namespace AdoPet.Services.PetAdoption.Application.Commands;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Result<PetDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePetCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PetDto>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();

        var shelter = shelters.SingleOrDefault(s =>
            s.Pets.Any(p => p.Id == request.Id));

        if (shelter is null)
            return new NotFoundError($"Pet with id {request.Id} not found");

        if (shelter.Adoptions.Any(a => a.PetId == request.Id))
            return new ConflictError($"Pet with id {request.Id} is already adopted");

        var pet = shelter.Pets.Single(p => p.Id == request.Id);

        if (request.ShelterId == shelter.Id)
        {
            pet.Update(request.Name, request.Age, request.Size, request.Description, request.Photo);
        }
        else
        {
            var oldShelter = shelter;
            shelter = shelters.SingleOrDefault(s => s.Id == request.ShelterId);

            if (shelter is null)
                return new ConflictError($"Shelter with id {request.ShelterId} does not exist");

            oldShelter.RemovePet(pet);
            shelter.AddPet(pet);
        }

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