using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.CreateRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken
    ) : IRequest<LoginCommandResponse>;

internal sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.CreateRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}
