using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairSalonHygieneRatingFeatures.Commands.Create;
using AutoMapper;
using Domain.Entities.Project;

namespace Application.Features.ProjectFeatures.HairSalonHygieneRatingFeatures.Profiles;

public class HairSalonHygieneRatingProfiles : Profile
{
    public HairSalonHygieneRatingProfiles()
    {
        CreateMap<HairSalonHygieneRating, CreateHairSalonHygieneRatingCommandResponse>()
           .ForMember(dest => dest.HairSalonId, opt => opt.MapFrom(src => src.HairSalonId))
           .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));

       // CreateMap<HairSalonHygieneRating, GetAllHairSalonHygieneRatingResponse>().ReverseMap();
    }
}