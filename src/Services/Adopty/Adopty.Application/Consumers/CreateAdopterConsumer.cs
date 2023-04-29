namespace Adopty.Application.Consumers;

public class CreateAdopterConsumer : IConsumer<CreateAdopter>
{
    private readonly IGenericRepository<Adopter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAdopterConsumer(IGenericRepository<Adopter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<CreateAdopter> context)
    {
        var message = context.Message;
        var adopter = new Adopter(message.Photo, message.Name, message.Phone, message.City, message.About, message.UserId);
        _repository.Add(adopter);
        await _unitOfWork.CommitAsync();
        var result = new CreateAdopterResult
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