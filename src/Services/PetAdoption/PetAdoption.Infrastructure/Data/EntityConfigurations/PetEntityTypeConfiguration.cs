namespace AdoPet.Services.PetAdoption.Infrastructure.Data.EntityConfigurations;

public class PetEntityTypeConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasOne<Shelter>()
            .WithMany(s => s.Pets)
            .HasForeignKey("ShelterId")
            .IsRequired();
    }
}