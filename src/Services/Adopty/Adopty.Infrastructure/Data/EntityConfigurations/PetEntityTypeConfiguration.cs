namespace Adopty.Infrastructure.Data.EntityConfigurations;

public class PetEntityTypeConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id);

        builder.Property(p => p.Photo);

        builder.Property(p => p.Name);

        builder.Property(p => p.Age);

        builder.Property(p => p.Size);

        builder.Property(p => p.Description);

        builder.Property(p => p.ShelterId);

        builder.HasOne(p => p.Shelter)
            .WithMany(p => p.Pets)
            .HasForeignKey(p => p.ShelterId);

        builder.HasOne(p => p.Adoption)
            .WithOne(p => p.Pet)
            .HasForeignKey<Adoption>(p => p.PetId);
    }
}