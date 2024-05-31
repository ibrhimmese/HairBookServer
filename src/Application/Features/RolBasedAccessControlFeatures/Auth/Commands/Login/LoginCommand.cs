using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;

public sealed record LoginCommand(
string UserNameOrEmail,
string Password
) : IRequest<LoginCommandResponse>;


internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.LoginAsync(request, cancellationToken);

        return response;
    }
}