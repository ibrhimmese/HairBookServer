using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetList;

public class GetListServicesQuery : IRequest<GetListResponse<GetListServicesListItemDto>>
{
    public PageRequest? PageRequest { get; set; }
}

internal sealed class GetListServicesQueryHandler(
    IServiceRepository serviceRepository,
    IMapper mapper
    ) : IRequestHandler<GetListServicesQuery, GetListResponse<GetListServicesListItemDto>>
{
    public async Task<GetListResponse<GetListServicesListItemDto>> Handle(GetListServicesQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Service> services = await serviceRepository.GetListAsync(
           index: request.PageRequest!.PageIndex,
           size: request.PageRequest.PageSize,
           cancellationToken: cancellationToken,
           withDeleted: false,
            include: p => p.Include(p => p.ServiceRatings)
            );
        GetListResponse<GetListServicesListItemDto> response = mapper
            .Map<GetListResponse<GetListServicesListItemDto>>(services);
        return response;    
    }
}
