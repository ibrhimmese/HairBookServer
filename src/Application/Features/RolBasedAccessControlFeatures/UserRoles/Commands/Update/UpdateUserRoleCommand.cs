using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Domain.Entities.RolBasedAccessControlEntities;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Update;

public class UpdateUserRoleCommand:IRequest<MessageResponse>
{
    public Guid Id { get; set; }
    public string RoleId { get; set; }=string.Empty;

}

internal sealed class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UpdateUserRoleCommandHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }
    public async Task<MessageResponse> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole? userRole = await _userRoleRepository.GetAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        userRole!.RoleId = request.RoleId;
        await _userRoleRepository.UpdateAsync(userRole,cancellationToken);
        return new("Kullanıcı Yetkisi Başarıyla Güncellendi");
    }
}
