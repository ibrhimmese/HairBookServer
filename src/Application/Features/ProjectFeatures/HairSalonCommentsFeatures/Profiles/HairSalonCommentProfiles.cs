using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonCommentsFeatures.Commands.Create;
using AutoMapper;
using Domain.Entities.Project;

namespace Application.Features.ProjectFeatures.HairSalonCommentsFeatures.Profiles;

public class HairSalonCommentProfiles:Profile
{
    public HairSalonCommentProfiles()
    {
        CreateMap<HairSalonComment, CreateHairSalonCommentCommand>().ReverseMap();
        CreateMap<HairSalonComment, CreatedHairSalonCommentCommandResponse>().ReverseMap();
        CreateMap<CreateHairSalonCommentCommand, CreatedHairSalonCommentCommandResponse>().ReverseMap();
    }
}
