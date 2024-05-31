using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Domain.Entities.RolBasedAccessControlEntities;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Delete;

public class DeleteUserRoleCommand:IRequest<MessageResponse>
{
    public Guid Id { get; set; }
}

internal sealed class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public DeleteUserRoleCommandHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<MessageResponse> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole? userRole = await _userRoleRepository.GetAsync(p=>p.Id == request.Id,cancellationToken:cancellationToken);
        var deletedUserRole = await _userRoleRepository.DeleteAsync(userRole!,cancellationToken:cancellationToken);

        return new("Kullanıcıya atanmış olan rol başarıyla silindi");
    }
}
