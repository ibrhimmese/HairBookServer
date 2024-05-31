using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;

public class GetAllHairDresserQuery:IRequest<List<GetAllHairDresserQueryResponse>>
{
}

internal sealed class GetAllHairDresserQueryHandler
    (
      IHairDresserRepository hairDresserRepository,
      IMapper mapper
    )
    : IRequestHandler<GetAllHairDresserQuery, List<GetAllHairDresserQueryResponse>>
{
    public async Task<List<GetAllHairDresserQueryResponse>> Handle(GetAllHairDresserQuery request, CancellationToken cancellationToken)
    {
        List<HairDresser> hairDressers = await hairDresserRepository.GetAllNoPaginateAsync(
            cancellationToken:cancellationToken,
            include:p=>p.Include(p=>p.HairDresserRatings)            
            );
        List<GetAllHairDresserQueryResponse> response = mapper.Map<List<GetAllHairDresserQueryResponse>>(hairDressers);
        return response;
    }
}
