namespace AdoPet.Services.PetAdoption.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AdoptionContext _context;

    public UnitOfWork(AdoptionContext context)
    {
        _context = context;
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}