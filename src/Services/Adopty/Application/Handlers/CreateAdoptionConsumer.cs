namespace Adopty.Application.Handlers;

public class CreateAdoptionConsumer : IConsumer<CreateAdoption>
{
    private readonly IAdoptionRepository _repository;

    public CreateAdoptionConsumer(IAdoptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<CreateAdoption> context)
    {
        var message = context.Message;
        var adoption = new Adoption(
            message.AdopterId,
            message.PetId);

        _repository.Add(adoption);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new CreateAdoptionResult(
                adoption.Id,
                adoption.AdopterId,
                adoption.PetId));
    }
}