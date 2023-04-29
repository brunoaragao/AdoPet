namespace Adopty.Application.Consumers;

public class UpdateAdopterConsumer : IConsumer<UpdateAdopter>
{
    private readonly IGenericRepository<Adopter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAdopterConsumer(IGenericRepository<Adopter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<UpdateAdopter> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByIdAsync(message.Id);
        adopter.SetPhoto(message.Photo);
        adopter.SetName(message.Name);
        adopter.SetPhone(message.Phone);
        adopter.SetCity(message.City);
        adopter.SetAbout(message.About);
        adopter.SetUserId(message.UserId);
        await _unitOfWork.CommitAsync();
        var result = new UpdateAdopterResult
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