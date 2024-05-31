using FluentValidation;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Rol adı boş olamaz");
    }
}
