using FluentValidation;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Create;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().NotNull().WithMessage("User alanı boş olamaz");
        RuleFor(p => p.RoleId).NotEmpty().NotNull().WithMessage("Rol alanı boş olamaz");
    }
}
