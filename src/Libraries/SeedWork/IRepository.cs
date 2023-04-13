namespace AdoPet.Libraries.SeedWork;

public interface IRepository<T> where T : Entity, IAggregateRoot
{
}