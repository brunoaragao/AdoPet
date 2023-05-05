namespace Adopty.Infrastructure.Data.Repositories;

public class AdoptionRepository : IAdoptionRepository
{
    private readonly AdoptyContext _context;

    public AdoptionRepository(AdoptyContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public void Add(Adoption entity)
    {
        _context.Adoptions.Add(entity);
    }

    public void Delete(Adoption entity)
    {
        _context.Adoptions.Remove(entity);
    }

    public async Task<Adoption?> GetByIdAsync(Guid id)
    {
        return await _context.Adoptions.FindAsync(id);
    }

    public async Task<IEnumerable<Adoption>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.Adoptions
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<Adoption>> GetByPageAsync(
        int pageNumber,
        int pageSize)
    {
        return await _context.Adoptions
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}