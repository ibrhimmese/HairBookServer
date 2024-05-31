using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;

public class GetByIdServiceQuery : IRequest<GetByIdServiceResponse>
{
    public Guid Id { get; set; }
}

internal sealed class GetByIdServiceQueryHandler(
    IServiceRepository serviceRepository,
    IMapper mapper
    ) : IRequestHandler<GetByIdServiceQuery, GetByIdServiceResponse>
{
    public async Task<GetByIdServiceResponse> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
    {
        Service? service = await serviceRepository.GetAsync(
            p => p.Id == request.Id,
             include: p => p.Include(p => p.ServiceRatings)
            );
        if (service is null) throw new Exception("Kuaför bulunamadı!");

        GetByIdServiceResponse response = mapper.Map<GetByIdServiceResponse>(service);
        return response;

    }
}