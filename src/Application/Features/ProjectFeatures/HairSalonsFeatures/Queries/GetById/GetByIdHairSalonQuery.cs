using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetById;

public class GetByIdHairSalonQuery:IRequest<GetByIdHairSalonResponse>
{
    public Guid Id { get; set; }
}

internal sealed class GetByIdHairSalonQueryHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : IRequestHandler<GetByIdHairSalonQuery, GetByIdHairSalonResponse>
{
    public async Task<GetByIdHairSalonResponse> Handle(GetByIdHairSalonQuery request, CancellationToken cancellationToken)
    {
        HairSalon? hairSalon = await hairSalonRepository.GetAsync(
            p => p.Id == request.Id,
            include: p => 
            p.Include(p => p.Services)
              .ThenInclude(p=>p.ServiceRatings)
            .Include(p => p.HairDressers)
              .ThenInclude(p => p.HairDresserRatings)
             .Include(p => p.HairSalonComments)
             .Include(p => p.HairSalonHygieneRatings)
             .Include(p => p.Images)
            );
        if (hairSalon is null) throw new Exception("Kuaför bulunamadı!");

        GetByIdHairSalonResponse response = mapper.Map<GetByIdHairSalonResponse>(hairSalon);
        return response;

    }
}