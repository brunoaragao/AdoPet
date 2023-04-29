namespace Identity.Api.Data.EntityConfigurations;

public class IdentityRoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityRole<Guid>
            {
                Id = new Guid("1bc58ea4-d404-4127-b308-66d11e85cb54"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole<Guid>
            {
                Id = new Guid("2a2676f1-08b2-477d-99f8-f93c1a89d778"),
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole<Guid>
            {
                Id = new Guid("9abed168-b8d5-428e-a6bf-62fd804143df"),
                Name = "Adopter",
                NormalizedName = "ADOPTER"
            },
            new IdentityRole<Guid>
            {
                Id = new Guid("17fabcf6-6c65-4b3d-a2fe-8c33534ccf20"),
                Name = "Shelter",
                NormalizedName = "SHELTER"
            }
        );
    }
}