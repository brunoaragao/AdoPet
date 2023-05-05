namespace Adopty.Application.Handlers;

public class DeleteAdoptionConsumer : IConsumer<DeleteAdoption>
{
    private readonly IAdoptionRepository _repository;

    public DeleteAdoptionConsumer(IAdoptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<DeleteAdoption> context)
    {
        var adoption = await _repository.GetByIdAsync(context.Message.Id);

        if (adoption is null)
        {
            throw new KeyNotFoundException($"Adoption with id {context.Message.Id} not found.");
        }

        _repository.Delete(adoption);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
                new DeleteAdoptionResult(
                    adoption.Id,
                    adoption.AdopterId,
                    adoption.PetId));
    }
}