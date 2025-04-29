using FluentValidation;

namespace Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir rol ID'si girilmelidir.");
        }
    }
}
