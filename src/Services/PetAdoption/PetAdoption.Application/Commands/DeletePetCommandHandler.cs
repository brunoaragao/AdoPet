namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, Result<PetDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePetCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PetDto>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();

        var shelter = shelters.SingleOrDefault(s =>
            s.Pets.Any(p => p.Id == request.Id));

        if (shelter is null)
            return new NotFoundError($"Pet with id {request.Id} not found");

        var pet = shelter.Pets.Single(p => p.Id == request.Id);
        shelter.RemovePet(pet);

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