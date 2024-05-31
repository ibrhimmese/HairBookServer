using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Create;

public sealed record CreateUserRoleCommand(
string RoleId,
string UserId
) : IRequest<MessageResponse>;

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.CreateAsync(request, cancellationToken).ConfigureAwait(false);
        return new("Kullanıcıya rol başarıyla atandı");
    }
}
