namespace Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;

public class CreatedHairDresserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? PhoneNumber { get; set; }
    public Guid HairSalonId { get; set; }
    public CreatedHairDresserResponse()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
}
