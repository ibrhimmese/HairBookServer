using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Update;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetList;
using AutoMapper;
using Domain.Entities.Project;
using IMFrameworkCore;

namespace Application.Features.ProjectFeatures.ServicesFeatures.Profiles;

public class ServiceMappingProfiles : Profile
{
    public ServiceMappingProfiles()
    {
        CreateMap<Service, CreateServiceCommand>().ReverseMap();
        CreateMap<Service, CreatedServiceResponse>().ReverseMap();
        CreateMap<CreateServiceCommand, CreatedServiceResponse>().ReverseMap();

        CreateMap<Service,DeletedServiceCommandResponse>().ReverseMap();

        CreateMap<Service, UpdateServiceCommand>().ReverseMap();
        CreateMap<Service, UpdatedServiceCommandResponse>().ReverseMap();

        CreateMap<Service, GetListServicesListItemDto>().ReverseMap();
        CreateMap<IPaginate<Service>, GetListResponse<GetListServicesListItemDto>>().ReverseMap();

        CreateMap<Service, GetAllServicesResponse>().ReverseMap();
        CreateMap<List<Service>, GetAllServicesResponse>().ReverseMap();

        CreateMap<Service, GetByIdServiceResponse>().ReverseMap();
    }
}
