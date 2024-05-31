namespace Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;

public class GetByIdServiceResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }

    public Guid? HairSalonId { get; set; }
    public GetByIdServiceResponse()
    {
        Name = string.Empty;
    }
}
