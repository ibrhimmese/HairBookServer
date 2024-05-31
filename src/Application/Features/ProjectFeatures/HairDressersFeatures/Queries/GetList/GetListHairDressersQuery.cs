using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetList;

public class GetListHairDressersQuery:IRequest<GetListResponse<GetListHairDressersListItemDto>>
{
    public PageRequest? PageRequest { get; set; }
}

internal sealed class GetListHairDressersQueryHandler(
    IHairDresserRepository hairDresserRepository,
    IMapper mapper
    ) : IRequestHandler<GetListHairDressersQuery, GetListResponse<GetListHairDressersListItemDto>>
{
    public async Task<GetListResponse<GetListHairDressersListItemDto>> Handle(GetListHairDressersQuery request, CancellationToken cancellationToken)
    {
        IPaginate<HairDresser> hairDressers = await hairDresserRepository.GetListAsync(
           index: request.PageRequest!.PageIndex,
           size: request.PageRequest.PageSize,
           cancellationToken: cancellationToken,
           withDeleted: false,
           include:p=>p.Include(p=>p.HairDresserRatings)
           );
        GetListResponse<GetListHairDressersListItemDto> response = mapper
            .Map<GetListResponse<GetListHairDressersListItemDto>>(hairDressers);

        return response;
    }
}
