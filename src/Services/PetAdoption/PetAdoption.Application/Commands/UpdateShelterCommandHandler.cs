namespace AdoPet.Services.PetAdoption.Application.Commands;

public class UpdateShelterCommandHandler : IRequestHandler<UpdateShelterCommand, Result<ShelterDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShelterCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShelterDto>> Handle(UpdateShelterCommand request, CancellationToken cancellationToken)
    {
        var shelter = await _shelterRepository.GetByIdAsync(request.Id);

        if (shelter is null)
            return new NotFoundError($"Shelter with id {request.Id} not found");

        shelter.Update(request.Name, request.Address);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new ShelterDto
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address
        };
    }
}
