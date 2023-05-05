namespace Adopty.Application.Handlers;

public class GetSheltersByPageConsumer : IConsumer<GetSheltersByPage>
{
    private readonly IShelterRepository _repository;

    public GetSheltersByPageConsumer(IShelterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetSheltersByPage> context)
    {
        var message = context.Message;
        var shelters = await _repository.GetByPageAsync(
            message.PageNumber,
            message.PageSize);

        await context.RespondAsync(
            new GetSheltersByPageResult(
                shelters.Select(
                    shelter => new GetSheltersByPageResultItem(
                        shelter.Id,
                        shelter.Address,
                        shelter.UserId))));
    }
}