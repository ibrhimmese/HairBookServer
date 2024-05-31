using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;
using System.Drawing.Drawing2D;

namespace Application.Features.ProjectFeatures.HairDressersFeatures.Profiles;

public class HairDresserProfiles : Profile
{
    public HairDresserProfiles()
    {
        CreateMap<HairDresser, CreateHairDresserCommand>().ReverseMap();
        CreateMap<HairDresser, CreatedHairDresserResponse>().ReverseMap();
        CreateMap<CreateHairDresserCommand, CreatedHairDresserResponse>().ReverseMap();

        CreateMap<HairDresser, DeletedHairDresserResponse>().ReverseMap();

        CreateMap<HairDresser, UpdateHairDresserCommand>().ReverseMap();
        CreateMap<HairDresser, UpdatedHairDresserResponse>().ReverseMap();

        CreateMap<HairDresser, GetListHairDressersListItemDto>().ReverseMap();
        CreateMap<IPaginate<HairDresser>, GetListResponse<GetListHairDressersListItemDto>>().ReverseMap();

        CreateMap<HairDresser, GetAllHairDresserQueryResponse>().ReverseMap();
        CreateMap<List<HairDresser>, GetAllHairDresserQueryResponse>().ReverseMap();

        CreateMap<HairDresser,GetByIdHairDresserResponse>().ReverseMap();
    }
}
