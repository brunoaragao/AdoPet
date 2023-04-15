namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, Result<ShelterDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateShelterCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShelterDto>> Handle(CreateShelterCommand request, CancellationToken cancellationToken)
    {
        var shelter = new Shelter(request.Name, request.Address);
        _shelterRepository.Add(shelter);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new ShelterDto
        {
            Id = shelter.Id,
            Name = shelter.Name,
            Address = shelter.Address
        };
    }
}
