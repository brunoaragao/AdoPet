namespace Adopty.Application.Handlers;

public class CreateAdopterConsumer : IConsumer<CreateAdopter>
{
    private readonly IAdopterRepository _repository;

    public CreateAdopterConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<CreateAdopter> context)
    {
        var message = context.Message;
        var adopter = new Adopter(
            message.UserId,
            message.Photo,
            message.Name,
            message.Phone,
            message.City,
            message.About);

        _repository.Add(adopter);
        await _repository.UnitOfWork.CommitAsync();

        await context.RespondAsync(
            new CreateAdopterResult(
                adopter.Id,
                adopter.UserId,
                adopter.Photo,
                adopter.Name,
                adopter.Phone,
                adopter.City,
                adopter.About));
    }
}