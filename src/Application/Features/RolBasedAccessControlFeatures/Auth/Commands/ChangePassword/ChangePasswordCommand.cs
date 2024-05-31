using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePassword;

public sealed record ChangePasswordCommand(
    string UserId,
    string OldPassword,
    string NewPassword
    ):IRequest<MessageResponse>;

internal sealed class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public ChangePasswordCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await _authService.ChangePasswordAsync(request, cancellationToken).ConfigureAwait(false);
        return new("Şifre Başarıyla Güncellendi");
    }
}

