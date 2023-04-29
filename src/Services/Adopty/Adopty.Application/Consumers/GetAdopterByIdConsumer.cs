namespace Adopty.Application.Consumers;

public class GetAdopterByIdConsumer : IConsumer<GetAdopterById>
{
    private readonly IGenericRepository<Adopter> _repository;

    public GetAdopterByIdConsumer(IGenericRepository<Adopter> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GetAdopterById> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByIdAsync(message.Id);
        var result = new GetAdopterByIdResult
        {
            Id = adopter.Id,
            Photo = adopter.Photo,
            Name = adopter.Name,
            Phone = adopter.Phone,
            City = adopter.City,
            About = adopter.About,
            UserId = adopter.UserId
        };
        await context.RespondAsync(result);
    }
}