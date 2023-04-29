namespace Adopty.Application.Consumers;

public class GetAdoptersByPageConsumer : IConsumer<GetAdoptersByPage>
{
    private readonly IGenericRepository<Adopter> _repository;

    public GetAdoptersByPageConsumer(IGenericRepository<Adopter> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdoptersByPage> context)
    {
        var message = context.Message;
        var adopters = await _repository.GetByPageAsync(message.Page, message.Size);
        var result = new GetAdoptersByPageResult
        {
            Items = adopters.Select(adopter => new GetAdoptersByPageResultItem
            {
                Id = adopter.Id,
                Photo = adopter.Photo,
                Name = adopter.Name,
                Phone = adopter.Phone,
                City = adopter.City,
                About = adopter.About,
                UserId = adopter.UserId
            })
        };
        await context.RespondAsync(result);
    }
}