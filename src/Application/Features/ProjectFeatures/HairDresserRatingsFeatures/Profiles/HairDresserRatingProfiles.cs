using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Queries.GetAll;
using AutoMapper;
using Domain.Entities.Project;

namespace Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Profiles;

public class HairDresserRatingProfiles : Profile
{
    public HairDresserRatingProfiles()
    {
        CreateMap<HairDresserRating, CreatedHairDresserRatingResponse>()
            .ForMember(dest => dest.HairDresserId, opt => opt.MapFrom(src => src.HairDresserId))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));

        CreateMap<HairDresserRating, GetAllHairDresserRatingResponse>().ReverseMap(); 
    }
}