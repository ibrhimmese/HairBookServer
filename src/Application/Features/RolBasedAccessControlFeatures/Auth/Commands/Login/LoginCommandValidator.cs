using FluentValidation;

namespace Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().NotNull().WithMessage("Mail Bilgisi veya Kullanıcı Adı alanı Boş olamaz");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(5).WithMessage("Kullanıcı Adı En Az 5 Karakter Olmalıdır");

        RuleFor(p => p.Password).NotEmpty().NotNull().WithMessage("Şifre Boş Olamaz");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir");
    }
}
