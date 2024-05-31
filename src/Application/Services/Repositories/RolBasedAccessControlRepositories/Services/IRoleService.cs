using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Update;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.Services;

public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteRoleCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateRoleCommand request, CancellationToken cancellationToken);
}
