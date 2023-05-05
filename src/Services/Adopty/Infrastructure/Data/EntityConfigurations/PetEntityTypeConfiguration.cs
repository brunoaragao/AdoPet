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

        builder.HasOne<Shelter>()
            .WithMany()
            .HasForeignKey(p => p.ShelterId)
            .IsRequired();

        builder.HasOne<Adoption>()
            .WithOne()
            .HasForeignKey<Adoption>(a => a.PetId);
    }
}