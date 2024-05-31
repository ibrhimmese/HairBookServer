using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Update;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Domain.Entities.RolBasedAccessControlEntities;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories.RolBasedAccessControlRepositories.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CreateAsync(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = new() { Name = request.Name };
        await _roleManager.CreateAsync(role);
    }

    public async Task DeleteAsync(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
       Role? role= await _roleManager.FindByIdAsync(request.Id);
        if (role is null)
        {
            throw new Exception("Belirttiğiniz Rol Bulunamadı");
        }
        await _roleManager.DeleteAsync(role);
    }

    public async Task UpdateAsync(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role? role = await _roleManager.FindByIdAsync(request.Id);
        if (role is null)
        {
            throw new Exception("Belirttiğiniz Rol Bulunamadı");
        }

        role.Name = request.Name;
        await _roleManager.UpdateAsync(role);
    }
}
