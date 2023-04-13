namespace AdoPet.Services.PetAdoption.Application.Commands;

public class UpdateAdopterCommandHandler : IRequestHandler<UpdateAdopterCommand, Result<AdopterDto>>
{
    private readonly IAdopterRepository _adopterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAdopterCommandHandler(IAdopterRepository adopterRepository, IUnitOfWork unitOfWork)
    {
        _adopterRepository = adopterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AdopterDto>> Handle(UpdateAdopterCommand request, CancellationToken cancellationToken)
    {
        var adopter = await _adopterRepository.GetByIdAsync(request.Id);
        if (adopter is null)
        {
            return new NotFoundError($"Adopter with id {request.Id} not found");
        }

        adopter.Update(request.Name, request.Email, request.Phone, request.Address, request.Photo, request.Description);

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