using FluentValidation;

namespace Application.Features.Roles.Commands.Update
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir rol ID'si belirtilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş olamaz.")
                 .MinimumLength(2).WithMessage("Rol adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Rol adı en fazla 100 karakter olabilir.");
        }
    }
}
