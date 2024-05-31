namespace Application.Features.ProjectFeatures.ServicesFeatures.Commands.Delete;

public class DeletedServiceCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid HairSalonId { get; set; }
    public DateTime DeletedDate { get; set; }
}
