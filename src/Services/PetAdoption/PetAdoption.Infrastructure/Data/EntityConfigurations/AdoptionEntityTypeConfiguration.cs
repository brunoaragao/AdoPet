namespace AdoPet.Services.PetAdoption.Infrastructure.Data.EntityConfigurations;

public class AdoptionEntityTypeConfiguration : IEntityTypeConfiguration<Adoption>
{
    public void Configure(EntityTypeBuilder<Adoption> builder)
    {
        builder.HasOne<Adopter>()
            .WithMany()
            .HasForeignKey(a => a.AdopterId);

        builder.HasOne<Pet>()
            .WithOne()
            .HasForeignKey<Adoption>(a => a.PetId);

        builder.HasOne<Shelter>()
            .WithMany(s => s.Adoptions)
            .IsRequired();
    }
}