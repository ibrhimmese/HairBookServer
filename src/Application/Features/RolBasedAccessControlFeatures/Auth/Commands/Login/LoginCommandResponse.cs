namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;

public sealed record LoginCommandResponse(
 string Token,
 string RefreshToken,
 DateTime? RefreshTokenExpires,
 string UserId
 );
