using Application.Features.PaymentMethods.Commands.Create;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.Roles.Commands.Create
{
    public class CreateRoleValidator : AbstractValidator<Role>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş olamaz.")
                .MinimumLength(2).WithMessage("Rol adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Rol adı en fazla 100 karakter olabilir.");
        }
    }
}
