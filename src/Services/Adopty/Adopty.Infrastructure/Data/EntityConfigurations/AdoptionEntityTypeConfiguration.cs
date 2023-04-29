namespace Adopty.Infrastructure.Data.EntityConfigurations;

public class AdoptionEntityTypeConfiguration : IEntityTypeConfiguration<Adoption>
{
    public void Configure(EntityTypeBuilder<Adoption> builder)
    {
        builder.ToTable("Adoption");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id);

        builder.Property(a => a.PetId);

        builder.Property(a => a.AdopterId);

        builder.HasOne(a => a.Pet)
            .WithOne(a => a.Adoption)
            .HasForeignKey<Adoption>(a => a.PetId);

        builder.HasOne(a => a.Adopter)
            .WithMany(a => a.Adoptions)
            .HasForeignKey(a => a.AdopterId);

        builder.HasIndex(a => new { a.PetId, a.AdopterId })
            .IsUnique();
    }
}