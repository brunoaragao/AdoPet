namespace Adopty.Application.Handlers;

public class CreateShelterConsumer : IConsumer<CreateShelter>
{
    private readonly IShelterRepository _repository;

    public CreateShelterConsumer(IShelterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<CreateShelter> context)
    {
        var message = context.Message;
        var shelter = new Shelter(
            message.UserId,
            message.Address);

        _repository.Add(shelter);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new CreateShelterResult(
                shelter.Id,
                shelter.Address,
                shelter.UserId));
    }
}