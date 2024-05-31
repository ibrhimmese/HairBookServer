using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using AutoMapper;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Update;

public class UpdateRoleCommand:IRequest<MessageResponse>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

internal sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;
    

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.UpdateAsync(request, cancellationToken);

        return new("Rol Başarıyla Güncellendi.");
    }
}
