using Application.Features.RolBasedAccessControlFeatures.Roles.Queries.GetAll;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Profiles;

public class RoleProfiles:Profile
{
    public RoleProfiles()
    {
        CreateMap<Role, GetAllRolesDto>().ReverseMap();
    }
}
