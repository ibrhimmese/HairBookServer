using Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Create;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.Services;

public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
}
