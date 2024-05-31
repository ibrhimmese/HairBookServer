using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Infrastructure.Responses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePasswordAdmin;

public sealed record  ChangePasswordAdminCommand(
    string UserId,
    string NewPassword
    ):IRequest<MessageResponse>;


internal sealed class ChangePasswordAdminCommandHandler : IRequestHandler<ChangePasswordAdminCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public ChangePasswordAdminCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(ChangePasswordAdminCommand request, CancellationToken cancellationToken)
    {
        await _authService.ChangePasswordAdminAsync(request, cancellationToken);

        return new("Şifre Değiştirildi");
    }
}
