namespace Adopty.Application.Consumers;

public class UpdateAdoptionConsumer : IConsumer<UpdateAdoption>
{
    private readonly IGenericRepository<Adoption> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAdoptionConsumer(IGenericRepository<Adoption> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<UpdateAdoption> context)
    {
        var message = context.Message;
        var adoption = await _repository.GetByIdAsync(message.Id);
        adoption.SetAdopterId(message.AdopterId);
        adoption.SetPetId(message.PetId);
        await _unitOfWork.CommitAsync();
        var result = new UpdateAdoptionResult
        {
            Id = adoption.Id,
            AdopterId = adoption.AdopterId,
            PetId = adoption.PetId
        };
        await context.RespondAsync(result);
    }
}