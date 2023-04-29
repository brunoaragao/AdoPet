namespace Adopty.Application.Consumers;

public class DeleteAdoptionConsumer : IConsumer<DeleteAdoption>
{
    private readonly IGenericRepository<Adoption> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAdoptionConsumer(IGenericRepository<Adoption> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<DeleteAdoption> context)
    {
        var message = context.Message;
        var adoption = await _repository.GetByIdAsync(message.Id);
        _repository.Delete(adoption);
        await _unitOfWork.CommitAsync();
        var result = new DeleteAdoptionResult
        {
            Id = adoption.Id,
            AdopterId = adoption.AdopterId,
            PetId = adoption.PetId
        };
        await context.RespondAsync(result);
    }
}