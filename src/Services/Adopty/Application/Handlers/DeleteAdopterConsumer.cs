namespace Adopty.Application.Handlers;

public class DeleteAdopterConsumer : IConsumer<DeleteAdopter>
{
    private readonly IAdopterRepository _repository;

    public DeleteAdopterConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<DeleteAdopter> context)
    {
        var adopter = await _repository.GetByIdAsync(context.Message.Id);

        if (adopter is null)
        {
            throw new KeyNotFoundException($"Adopter with id {context.Message.Id} not found.");
        }

        _repository.Delete(adopter);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new DeleteAdopterResult(
                adopter.Id,
                adopter.Photo,
                adopter.Name,
                adopter.Phone,
                adopter.City,
                adopter.About,
                adopter.UserId));
    }
}