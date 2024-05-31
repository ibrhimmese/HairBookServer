namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;

public class ServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }
    public ServiceDto()
    {
        Name = string.Empty;
    }
}
