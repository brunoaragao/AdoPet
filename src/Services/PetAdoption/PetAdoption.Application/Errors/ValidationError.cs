namespace AdoPet.Services.PetAdoption.Application.Errors;

public class ValidationError : Error
{
    public ValidationError(string message, string propertyName) : base(message)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; set; }
}