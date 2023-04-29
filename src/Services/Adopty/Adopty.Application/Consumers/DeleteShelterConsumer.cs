namespace Adopty.Application.Consumers;

public class DeleteShelterConsumer : IConsumer<DeleteShelter>
{
    private readonly IGenericRepository<Shelter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteShelterConsumer(IGenericRepository<Shelter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<DeleteShelter> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);
        _repository.Delete(shelter);
        await _unitOfWork.CommitAsync();
        var result = new DeleteShelterResult
        {
            Id = shelter.Id,
            Address = shelter.Address,
            UserId = shelter.UserId
        };
        await context.RespondAsync(result);
    }
}