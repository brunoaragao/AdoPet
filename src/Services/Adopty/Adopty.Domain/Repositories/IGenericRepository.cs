namespace Adopty.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object?>>[]? includes);
    Task<IEnumerable<TEntity>> GetByPageAsync(int page, int size, params Expression<Func<TEntity, object?>>[]? includes);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class;
    void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty?>> propertyExpression) where TProperty : class;
}