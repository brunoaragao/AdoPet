namespace Adopty.Application.Consumers;

public class UpdateAdopterByUserIdConsumer : IConsumer<UpdateAdopterByUserId>
{
    private readonly IAdoptersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAdopterByUserIdConsumer(IAdoptersRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<UpdateAdopterByUserId> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByUserIdAsync(message.UserId);
        adopter.SetPhoto(message.Photo);
        adopter.SetName(message.Name);
        adopter.SetPhone(message.Phone);
        adopter.SetCity(message.City);
        adopter.SetAbout(message.About);
        await _unitOfWork.CommitAsync();
        var result = new UpdateAdopterByUserIdResult
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