using Application.Features.RolBasedAccessControlFeatures.UserRoles.Queries.GetAll;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Profiles;

public class UserRoleProfiles:Profile
{
    public UserRoleProfiles()
    {
        CreateMap<UserRole, GetAllUserRolesResponse>()
            .ForMember(destinationMember: c => c.UserFullName, memberOptions: opt => opt.MapFrom(c => c.User!.FullName))
            .ForMember(destinationMember: c => c.RoleName, memberOptions: opt => opt.MapFrom(c => c.Role!.Name))
            .ReverseMap();
        CreateMap<List<UserRole>, GetListResponse<GetAllUserRolesResponse>>().ReverseMap();
    }
}
