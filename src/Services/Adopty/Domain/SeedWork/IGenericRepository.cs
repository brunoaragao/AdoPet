namespace Adopty.Domain.SeedWork;

public interface IGenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    void Add(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<IEnumerable<TEntity>> GetByPageAsync(int pageNumber, int pageSize);
    void Update(TEntity entity);
}