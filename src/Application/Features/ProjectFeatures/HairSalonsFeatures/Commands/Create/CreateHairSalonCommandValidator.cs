using FluentValidation;

namespace Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;

public class CreateHairSalonCommandValidator:AbstractValidator<CreateHairSalonCommand>
{
    public CreateHairSalonCommandValidator()
    {
        RuleFor(h => h.Name).NotEmpty().NotNull().WithMessage("İsim Alanı Boş Geçilemez");
        RuleFor(h => h.Email).NotEmpty().NotNull().WithMessage("Email Alanı Boş Geçilemez");
        RuleFor(h => h.Email).EmailAddress().WithMessage("Geçerli Bir Email Formatı Giriniz");
        RuleFor(h => h.PhoneNumber).NotEmpty().NotNull().WithMessage("Telefon alanı boş geçilemez");
        RuleFor(h => h.PhoneNumber).Matches(@"^(05(\d{9}))$").WithMessage("Geçerli Bir Telefon Numarası Giriniz");

    }
}
