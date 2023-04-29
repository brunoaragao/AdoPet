namespace Adopty.Application.Consumers;

public class DeleteAdopterConsumer : IConsumer<DeleteAdopter>
{
    private readonly IGenericRepository<Adopter> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAdopterConsumer(IGenericRepository<Adopter> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<DeleteAdopter> context)
    {
        var message = context.Message;
        var adopter = await _repository.GetByIdAsync(message.Id);
        _repository.Delete(adopter);
        await _unitOfWork.CommitAsync();
        var result = new DeleteAdopterResult
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