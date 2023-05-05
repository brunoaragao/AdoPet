namespace Adopty.Application.Handlers;

public class GetAdoptersByPageConsumer : IConsumer<GetAdoptersByPage>
{
    private readonly IAdopterRepository _repository;

    public GetAdoptersByPageConsumer(IAdopterRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptersByPage> context)
    {
        var message = context.Message;
        var adopters = await _repository.GetByPageAsync(
            message.PageNumber,
            message.PageSize);

        await context.RespondAsync(
            new GetAdoptersByPageResult(
                adopters.Select(
                    adopter => new GetAdoptersByPageResultItem(
                        adopter.Id,
                        adopter.Photo,
                        adopter.Name,
                        adopter.Phone,
                        adopter.City,
                        adopter.About,
                        adopter.UserId))));
    }
}