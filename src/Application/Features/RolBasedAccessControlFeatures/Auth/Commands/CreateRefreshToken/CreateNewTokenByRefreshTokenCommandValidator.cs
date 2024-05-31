using FluentValidation;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.CreateRefreshToken;

public class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().NotNull().WithMessage("Kullanıcı bilgisi boş olamaz");

        RuleFor(p => p.RefreshToken).NotEmpty().NotNull().WithMessage("Refresh Token bilgisi boş olamaz");

    }
}
