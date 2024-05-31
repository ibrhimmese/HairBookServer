using Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Create;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Domain.Entities.RolBasedAccessControlEntities;

namespace Persistence.Repositories.RolBasedAccessControlRepositories.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        };

        await _repository.AddAsync(userRole);
    }
}
