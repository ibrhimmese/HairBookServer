namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;

public class DeletedHairSalonCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }    
    public DateTime DeletedDate { get; set; }
    public DeletedHairSalonCommandResponse()
    {
        Name = string.Empty;
    }
}
