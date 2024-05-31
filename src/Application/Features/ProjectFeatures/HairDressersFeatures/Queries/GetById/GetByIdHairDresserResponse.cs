namespace Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;

public class GetByIdHairDresserResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public double Rating { get; set; }
    public Guid HairSalonId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public GetByIdHairDresserResponse()
    {
        FullName = string.Empty;
    }
}
