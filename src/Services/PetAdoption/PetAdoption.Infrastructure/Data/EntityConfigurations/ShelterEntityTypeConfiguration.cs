namespace AdoPet.Services.PetAdoption.Infrastructure.Data.EntityConfigurations;

public class ShelterEntityTypeConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> builder)
    {
        builder.Navigation(s => s.Pets)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude();

        builder.Navigation(s => s.Adoptions)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude();
    }
}