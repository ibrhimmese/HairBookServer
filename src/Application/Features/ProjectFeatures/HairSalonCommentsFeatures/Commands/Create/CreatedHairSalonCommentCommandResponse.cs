namespace Application.Features.ProjectFeatures.HairSalonCommentsFeatures.Commands.Create;

public class CreatedHairSalonCommentCommandResponse
{
    public string Message { get; set; }
    public Guid HairSalonId { get; set; }
    public CreatedHairSalonCommentCommandResponse()
    {
        Message = string.Empty;
    }
}