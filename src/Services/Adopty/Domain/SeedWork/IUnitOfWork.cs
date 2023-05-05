namespace Adopty.Domain.SeedWork;

public interface IUnitOfWork
{
    Task CommitAsync();
}