namespace Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;

public class CreatedServiceResponse
{
    public string Name { get; set; }=string.Empty;
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public Guid HairSalonId { get; set; }

}