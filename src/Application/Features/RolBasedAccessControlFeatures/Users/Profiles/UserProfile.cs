using Application.Features.RolBasedAccessControlFeatures.Users.Commands.Update;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetById;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetListToPaginate;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetAllResponseDto>().ReverseMap();
        CreateMap<User, UserPagedResponseDto>().ReverseMap();
        CreateMap<User, GetByIdResponseDto>().ReverseMap();
        CreateMap<UpdateUserCommand, User>()
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
    }
}
