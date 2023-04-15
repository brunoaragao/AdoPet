namespace AdoPet.Services.PetAdoption.Infrastructure.Data.Repositories;

public class AdopterRepository : IAdopterRepository
{
    private readonly AdoptionContext _context;

    public AdopterRepository(AdoptionContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Adopter>> GetAllAsync()
    {
        return await _context.Adopters.ToListAsync();
    }

    public async Task<Adopter?> GetByIdAsync(Guid id)
    {
        return await _context.Adopters.FindAsync(id);
    }

    public void Add(Adopter adopter)
    {
        _context.Adopters.Add(adopter);
    }

    public void Update(Adopter adopter)
    {
        _context.Adopters.Update(adopter);
    }

    public void Delete(Adopter adopter)
    {
        _context.Adopters.Remove(adopter);
    }
}