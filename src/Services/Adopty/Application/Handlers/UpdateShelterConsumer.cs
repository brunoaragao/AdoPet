namespace Adopty.Application.Handlers;

public class UpdateShelterConsumer : IConsumer<UpdateShelter>
{
    private readonly IShelterRepository _repository;

    public UpdateShelterConsumer(IShelterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<UpdateShelter> context)
    {
        var message = context.Message;
        var shelter = await _repository.GetByIdAsync(message.Id);

        if (shelter is null)
        {
            throw new KeyNotFoundException($"Shelter with id {message.Id} not found.");
        }

        shelter.UpdateAddress(message.Address);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new UpdateShelterResult(
                shelter.Id,
                shelter.Address,
                shelter.UserId));
    }
}