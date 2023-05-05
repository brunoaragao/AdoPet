namespace Adopty.Infrastructure.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(
        AdoptyContext context,
        IUnitOfWork unitOfWork)
    {
        _entities = context.Set<TEntity>();
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _entities
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetByPageAsync(
        int pageNumber,
        int pageSize)
    {
        return await _entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}