namespace AdoPet.Services.PetAdoption.Infrastructure.Data.Repositories;

public class ShelterRepository : IShelterRepository
{
    private readonly AdoptionContext _context;

    public ShelterRepository(AdoptionContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Shelter>> GetAllAsync()
    {
        return await _context.Shelters.ToListAsync();
    }

    public async Task<Shelter?> GetByIdAsync(Guid id)
    {
        return await _context.Shelters.FindAsync(id);
    }

    public void Add(Shelter shelter)
    {
        _context.Shelters.Add(shelter);
    }

    public void Update(Shelter shelter)
    {
        _context.Shelters.Update(shelter);
    }

    public void Delete(Shelter shelter)
    {
        _context.Shelters.Remove(shelter);
    }
}