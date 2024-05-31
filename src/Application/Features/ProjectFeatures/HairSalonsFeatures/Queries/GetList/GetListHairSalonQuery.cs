using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using CachingBehavior;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;

public sealed class GetListHairSalonQuery : IRequest<GetListResponse<GetListHairSalonListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest? PageRequest { get; set; }
    public string CacheKey => $"GetListHairSalonQuery({PageRequest!.PageIndex},{PageRequest.PageSize})";

    public bool ByPassCache  { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetHairSalons";


}

internal sealed class GetListHairSalonQueryHandler(
    IHairSalonRepository hairSalonRepository,
    IMapper mapper
    ) : 
    IRequestHandler<GetListHairSalonQuery, GetListResponse<GetListHairSalonListItemDto>>
{
    public async Task<GetListResponse<GetListHairSalonListItemDto>> Handle(GetListHairSalonQuery request, CancellationToken cancellationToken)
    {
        IPaginate<HairSalon> hairSalons = await hairSalonRepository.GetListAsync(
            index: request.PageRequest!.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken,
            withDeleted: false,
            include: p =>
            p.Include(p => p.Services)
              .ThenInclude(p => p.ServiceRatings)
            .Include(p => p.HairDressers)
              .ThenInclude(p => p.HairDresserRatings)
             .Include(p => p.HairSalonComments)
             .Include(p => p.HairSalonHygieneRatings)
             .Include(p => p.Images)
            );
        GetListResponse<GetListHairSalonListItemDto> response = mapper.Map<GetListResponse<GetListHairSalonListItemDto>>(hairSalons);
        return response;
    }
}
