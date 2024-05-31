using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;

public sealed class GetByIdHairDresserQuery : IRequest<GetByIdHairDresserResponse>
{
    public Guid Id { get; set; }
}

internal sealed class GetByIdHairDresserQueryHandler(
    IHairDresserRepository hairDresserRepository,
    IMapper mapper
    ) : IRequestHandler<GetByIdHairDresserQuery, GetByIdHairDresserResponse>
{
    public async Task<GetByIdHairDresserResponse> Handle(GetByIdHairDresserQuery request, CancellationToken cancellationToken)
    {
        HairDresser? hairDresser = await hairDresserRepository.GetAsync(
            p=>p.Id==request.Id,
            include: p => p.Include(p => p.HairDresserRatings)
            );
        if (hairDresser is null) throw new Exception("Kuaför bulunamadı!");

        GetByIdHairDresserResponse response = mapper.Map<GetByIdHairDresserResponse>(hairDresser);
        return response;

    }
}
