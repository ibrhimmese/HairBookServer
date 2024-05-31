namespace Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;

public class GetAllHairDresserQueryResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public double Rating { get; set; }
    public Guid HairSalonId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public GetAllHairDresserQueryResponse()
    {
        FullName = string.Empty;
    }
}
