namespace Adopty.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AdoptyContext _context;

    public UnitOfWork(AdoptyContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}