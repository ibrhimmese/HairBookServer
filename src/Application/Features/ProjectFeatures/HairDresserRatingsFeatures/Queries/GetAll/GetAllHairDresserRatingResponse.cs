namespace Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Queries.GetAll;

public class GetAllHairDresserRatingResponse
{
    public Guid Id { get; set; }
    public double Score { get; set; }
    public Guid HairDresserId { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
    public DateTime DeletedDate { get; set; }
}
