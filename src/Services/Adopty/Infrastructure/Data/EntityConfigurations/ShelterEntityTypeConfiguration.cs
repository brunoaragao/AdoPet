namespace Adopty.Infrastructure.Data.EntityConfigurations;

public class ShelterEntityTypeConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.ToTable("Shelter");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id);

        builder.Property(s => s.Address);

        builder.Property(s => s.UserId);

        builder.HasMany<Pet>()
            .WithOne()
            .HasForeignKey(p => p.ShelterId);

        builder.HasIndex(s => s.UserId)
            .IsUnique();
    }
}