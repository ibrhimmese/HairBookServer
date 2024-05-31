using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangeEmail;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePassword;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePasswordAdmin;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.CreateRefreshToken;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Register;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request,CancellationToken cancellationToken);

    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);

    Task ChangePasswordAsync(ChangePasswordCommand request, CancellationToken cancellationToken);
    Task ChangePasswordAdminAsync(ChangePasswordAdminCommand request, CancellationToken cancellationToken);
    Task ChangeEmailAsync(ChangeEmailCommand request, CancellationToken cancellationToken);

    Task<LoginCommandResponse> CreateRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);
}
