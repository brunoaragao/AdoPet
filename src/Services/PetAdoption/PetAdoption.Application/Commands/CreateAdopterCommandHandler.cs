namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateAdopterCommandHandler : IRequestHandler<CreateAdopterCommand, Result<AdopterDto>>
{
    private readonly IAdopterRepository _adopterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdopterCommandHandler(IAdopterRepository adopterRepository, IUnitOfWork unitOfWork)
    {
        _adopterRepository = adopterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AdopterDto>> Handle(CreateAdopterCommand request, CancellationToken cancellationToken)
    {
        var adopter = new Adopter(request.Name, request.Email, request.Phone, request.Address, request.Photo, request.Description);
        _adopterRepository.Add(adopter);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new AdopterDto
        {
            Id = adopter.Id,
            Name = adopter.Name,
            Email = adopter.Email,
            Phone = adopter.Phone,
            Address = adopter.Address,
            Photo = adopter.Photo,
            Description = adopter.Description
        };
    }
}