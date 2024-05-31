using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.Dtos;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Profiles;

public class HairSalonProfiles:Profile
{
    public HairSalonProfiles()
    {
        CreateMap<HairSalon,CreateHairSalonCommand>().ReverseMap();
        CreateMap<HairSalon, CreatedHairSalonResponse>().ReverseMap();
        CreateMap<CreateHairSalonCommand, CreatedHairSalonResponse>().ReverseMap();

       // CreateMap<CreateHairSalonCommand, HairSalon>(); //Addedd


        //CreateMap<Service, ServiceDto>().ReverseMap();
        //CreateMap<HairDresser, HairDresserDto>().ReverseMap();

        CreateMap<HairSalon,GetListHairSalonListItemDto>().ReverseMap();
        CreateMap<IPaginate<HairSalon>, GetListResponse<GetListHairSalonListItemDto>>().ReverseMap();

        CreateMap<HairSalon, DeletedHairSalonCommandResponse>().ReverseMap();

        CreateMap<HairSalon, UpdateHairSalonCommand>().ReverseMap();
        CreateMap<HairSalon, UpdatedHairSalonResponse>().ReverseMap();

        CreateMap<HairSalon, GetAllHairSalonsResponse>().ReverseMap();
        CreateMap<List<HairSalon>, GetAllHairSalonsResponse>().ReverseMap();

        CreateMap<HairDresser, HairDresserDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<HairSalonComment, HairSalonCommentDto>().ReverseMap();
        CreateMap<HairSalonImage, HairSalonImageDto>();


        CreateMap<HairSalon, GetByIdHairSalonResponse>().ReverseMap();


    }
}
