using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;

public class GetListHairSalonListItemDto
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
    public double? Rating { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public List<ServiceDto> Services { get; set; } = new();
    public List<HairDresserDto> HairDressers { get; set; } = new();
    public List<HairSalonCommentDto> HairSalonComments { get; set; } = new();
    public List<HairSalonImageDto> Images { get; set; } = new();

    public GetListHairSalonListItemDto()
    {
        Name = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Email = string.Empty;
        Description = string.Empty;
    }
}
