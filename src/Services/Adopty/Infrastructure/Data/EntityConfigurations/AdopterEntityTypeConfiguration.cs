namespace Adopty.Infrastructure.Data.EntityConfigurations;

public class AdopterEntityTypeConfiguration : IEntityTypeConfiguration<Adopter>
{
    public void Configure(EntityTypeBuilder<Adopter> builder)
    {
        builder.ToTable("Adopter");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id);

        builder.Property(a => a.Photo);

        builder.Property(a => a.Name);

        builder.Property(a => a.Phone);

        builder.Property(a => a.City);

        builder.Property(a => a.About);

        builder.Property(a => a.UserId);

        builder.HasMany<Adoption>()
            .WithOne()
            .HasForeignKey(adoption => adoption.AdopterId)
            .IsRequired();

        builder.HasIndex(a => a.UserId)
            .IsUnique();
    }
}