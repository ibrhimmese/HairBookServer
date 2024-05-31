namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;

public class HairSalonImageDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }=string.Empty;
    public string PublicId { get; set; } = string.Empty;

}
