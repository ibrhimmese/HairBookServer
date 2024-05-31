using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetAll;

public class GetAllServicesQuery:IRequest<List<GetAllServicesResponse>>
{
}

internal sealed class GetAllServicesQueryHandler(
    IServiceRepository serviceRepository,
    IMapper mapper
    ) : IRequestHandler<GetAllServicesQuery, List<GetAllServicesResponse>>
{
    public async Task<List<GetAllServicesResponse>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        List<Service> services = await serviceRepository.GetAllNoPaginateAsync(
            cancellationToken: cancellationToken,
            include: p => p.Include(p => p.ServiceRatings)
            );
        List<GetAllServicesResponse> response = mapper.Map<List<GetAllServicesResponse>>(services);
        return response;
    }
}
