namespace AdoPet.Services.PetAdoption.Application.Commands;

public class CreateAdopterCommand : IRequest<Result<AdopterDto>>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    public required string Photo { get; set; }
    public required string Description { get; set; }
}