namespace Adopty.Infrastructure.Data;

public class AdoptyContext : DbContext
{
    public AdoptyContext(DbContextOptions<AdoptyContext> options) : base(options)
    {
    }

    public DbSet<Adopter> Adopters => Set<Adopter>();
    public DbSet<Adoption> Adoptions => Set<Adoption>();
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Shelter> Shelters => Set<Shelter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdoptyContext).Assembly);
    }
}