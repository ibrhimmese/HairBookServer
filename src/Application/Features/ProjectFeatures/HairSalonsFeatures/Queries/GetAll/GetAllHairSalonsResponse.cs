using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;
using Domain.Entities.Project;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetAll;

public class GetAllHairSalonsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Description { get; set; }
    public double AverageServiceRating { get; set; }
    public double AverageHairDresserRating { get; set; }
    public double HygieneRating { get; set; }
    public double Rating { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public List<ServiceDto> Services { get; set; } = new();
    public List<HairDresserDto> HairDressers { get; set; } = new();
    public List<HairSalonCommentDto> HairSalonComments { get; set; } = new();
    public List<HairSalonImageDto> Images { get; set; } = new();


    public GetAllHairSalonsResponse()
    {
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
    }
}


