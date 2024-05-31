namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;

public class HairSalonCommentDto
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public HairSalonCommentDto()
    {
        Message = string.Empty;
    }
}
