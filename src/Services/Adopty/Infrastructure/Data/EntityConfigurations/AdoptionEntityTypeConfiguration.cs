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

        builder.HasOne<Pet>()
            .WithOne()
            .HasForeignKey<Adoption>(a => a.PetId)
            .IsRequired();

        builder.HasOne<Adopter>()
            .WithMany()
            .HasForeignKey(a => a.AdopterId)
            .IsRequired();
    }
}