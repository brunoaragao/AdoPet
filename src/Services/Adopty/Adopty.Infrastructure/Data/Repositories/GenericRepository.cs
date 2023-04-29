namespace Adopty.Infrastructure.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    protected readonly AdoptyContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AdoptyContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object?>>[]? includes)
    {
        var query = _dbSet.AsQueryable();

        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.SingleAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetByPageAsync(int page, int size, params Expression<Func<TEntity, object?>>[]? includes)
    {
        var query = _dbSet.AsQueryable();

        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query
            .OrderBy(x => x.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> property) where TProperty : class
    {
        _context.Entry(entity).Collection(property).Load();
    }

    public void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> property) where TProperty : class
    {
        _context.Entry(entity).Reference(property).Load();
    }
}