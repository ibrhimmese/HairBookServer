using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Domain.Entities.RolBasedAccessControlEntities;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.JwtProviderInterfaces;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}
