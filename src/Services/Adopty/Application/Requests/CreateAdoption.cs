namespace Adopty.Application.Requests;

public record CreateAdoption(
    Guid AdopterId,
    Guid PetId);