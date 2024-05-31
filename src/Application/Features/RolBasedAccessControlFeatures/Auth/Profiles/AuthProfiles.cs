using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Register;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Profiles;

public class AuthProfiles : Profile
{
    public AuthProfiles()
    {
        CreateMap<RegisterCommand, User>().ReverseMap();
    }
}
