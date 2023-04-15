namespace AdoPet.Services.PetAdoption.Infrastructure.Data;

public class AdoptionContext : DbContext
{
    public AdoptionContext(DbContextOptions<AdoptionContext> options) : base(options)
    {
    }

    public DbSet<Adopter> Adopters => Set<Adopter>();
    public DbSet<Shelter> Shelters => Set<Shelter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdoptionContext).Assembly);
    }
}