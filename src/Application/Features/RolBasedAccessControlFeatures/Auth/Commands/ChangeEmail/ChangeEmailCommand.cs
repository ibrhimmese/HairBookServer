using Application.Services.Repositories.RolBasedAccessControlRepositories.Services;
using Infrastructure.Responses;
using MediatR;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangeEmail;

public sealed record ChangeEmailCommand(
    string UserId,
    string NewEmail
    ):IRequest<MessageResponse>;

internal sealed class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public ChangeEmailCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        await _authService.ChangeEmailAsync(request, cancellationToken);
        return new("E posta başarıyla değiştirildi");
    }
}
