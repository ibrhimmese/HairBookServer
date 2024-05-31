using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Delete;

public sealed record DeleteRoleCommand(
    string Id
    ):IRequest<MessageResponse>;



public class DeleteRoleCommandResponse : IRequestHandler<DeleteRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandResponse(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.DeleteAsync(request, cancellationToken).ConfigureAwait(false);
        return new("Rol başarıyla Silindi");
    }
}