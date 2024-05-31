using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Services.Repositories.ProjectRepositories;
using AutoMapper;
using Domain.Entities.Project;
using MediatR;

namespace Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Queries.GetAll;

public class GetAllHairDresserRatingQuery:IRequest<List<GetAllHairDresserRatingResponse>>
{
}

internal sealed class GetAllHairDresserRatingQueryHandler(
    IHairDresserRatingRepository hairDresserRatingRepository,
    IMapper mapper
    ) : IRequestHandler<GetAllHairDresserRatingQuery, List<GetAllHairDresserRatingResponse>>
{
    public async Task<List<GetAllHairDresserRatingResponse>> Handle(GetAllHairDresserRatingQuery request, CancellationToken cancellationToken)
    {
        List<HairDresserRating>? hairDresserRatings = await hairDresserRatingRepository.GetAllNoPaginateAsync(cancellationToken: cancellationToken);

        List<GetAllHairDresserRatingResponse> response = mapper.Map<List<GetAllHairDresserRatingResponse>>(hairDresserRatings);

        return response;

    }
}
