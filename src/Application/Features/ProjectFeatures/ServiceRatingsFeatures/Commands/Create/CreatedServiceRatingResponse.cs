namespace Application.Features.ProjectFeatures.ServiceRatingsFeatures.Commands.Create;

public class CreatedServiceRatingResponse
{
    public Guid ServiceId { get; set; }
    public double AverageRating { get; set; }
}
