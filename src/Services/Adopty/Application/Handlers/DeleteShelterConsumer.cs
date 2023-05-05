namespace Adopty.Application.Handlers;

public class DeleteShelterConsumer : IConsumer<DeleteShelter>
{
    private readonly IShelterRepository _repository;

    public DeleteShelterConsumer(IShelterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<DeleteShelter> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);

        if (shelter is null)
        {
            throw new KeyNotFoundException($"Shelter with id {message.Id} not found.");
        }

        _repository.Delete(shelter);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new DeleteShelterResult(
                shelter.Id,
                shelter.Address,
                shelter.UserId));
    }
}