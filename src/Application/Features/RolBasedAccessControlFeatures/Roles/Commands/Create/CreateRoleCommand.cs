using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using IMFrameworkCore;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;

public sealed record CreateRoleCommand(
    string Name
    ) : IRequest<MessageResponse>, ILoggableRequest;

public class CreateRoleCommandResponse : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandResponse(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(request, cancellationToken).ConfigureAwait(false);
        return new("Rol başarıyla oluşturuldu");
    }
}
