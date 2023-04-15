namespace AdoPet.Services.PetAdoption.Application.Commands;

public class DeleteAdoptionCommandHandler : IRequestHandler<DeleteAdoptionCommand, Result<AdoptionDto>>
{
    private readonly IShelterRepository _shelterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAdoptionCommandHandler(IShelterRepository shelterRepository, IUnitOfWork unitOfWork)
    {
        _shelterRepository = shelterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AdoptionDto>> Handle(DeleteAdoptionCommand request, CancellationToken cancellationToken)
    {
        var shelters = await _shelterRepository.GetAllAsync();

        var shelter = shelters.SingleOrDefault(s =>
            s.Adoptions.Any(a => a.Id == request.Id));

        if (shelter is null)
            return new NotFoundError($"Adoption with id {request.Id} not found");

        var adoption = shelter.Adoptions.Single(a => a.Id == request.Id);
        shelter.RemoveAdoption(adoption);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new AdoptionDto
        {
            Id = adoption.Id,
            PetId = adoption.PetId,
            AdopterId = adoption.AdopterId
        };
    }
}