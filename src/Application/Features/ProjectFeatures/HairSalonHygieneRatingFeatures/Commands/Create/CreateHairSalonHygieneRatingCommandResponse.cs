namespace Application.Features.ProjectFeatures.HairSalonHygieneRatingFeatures.Commands.Create;

public class CreateHairSalonHygieneRatingCommandResponse
{
    public Guid HairSalonId { get; set; }
    public double Score { get; set; }
}