using IMFrameworkCore;
using MediatR;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetList;

public class GetListServicesListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Duration { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }

    public Guid? HairSalonId { get; set; }
    public GetListServicesListItemDto()
    {
        Name = string.Empty;
    }
}



