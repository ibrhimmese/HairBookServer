namespace Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;

public class UpdatedHairDresserResponse
{
    public string? FullName {  get; set; }
    public string? PhoneNumber { get; set; }
    public Guid HairSalonId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
   
}
