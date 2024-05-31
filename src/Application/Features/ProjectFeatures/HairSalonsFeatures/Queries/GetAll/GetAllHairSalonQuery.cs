using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetAll;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetAll;

public class GetAllHairSalonQuery:IRequest<List<GetAllHairSalonsResponse>>
{
}

internal sealed class GetAllHairSalonQueryHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<GetAllHairSalonQuery, List<GetAllHairSalonsResponse>>
{
    public async Task<List<GetAllHairSalonsResponse>> Handle(GetAllHairSalonQuery request, CancellationToken cancellationToken)
    {
        List<HairSalon> hairSalons = await hairSalonRepository.GetAllNoPaginateAsync(
            cancellationToken: cancellationToken,
            include: p =>
            p.Include(p => p.Services)
              .ThenInclude(p => p.ServiceRatings)
            .Include(p => p.HairDressers)
              .ThenInclude(p => p.HairDresserRatings)
            .Include(p=>p.HairSalonComments)
            .Include(p=>p.HairSalonHygieneRatings)
            .Include(p=>p.Images)
            );
        List<GetAllHairSalonsResponse> response = mapper.Map<List<GetAllHairSalonsResponse>>(hairSalons);
        return response;
    }
}