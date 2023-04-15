namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommand, Result<ShelterDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteShelterCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShelterDto>> Handle(DeleteShelterCommand request, CancellationToken cancellationToken)
    {
        var shelter = await _shelterRepository.GetByIdAsync(request.Id);

        if (shelter is null)
            return new NotFoundError($"Shelter with id {request.Id} not found");

        _shelterRepository.Delete(shelter);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new ShelterDto
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address
        };
    }
}
