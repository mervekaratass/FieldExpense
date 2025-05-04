using FluentValidation;

namespace Application.Features.ExpenseRequests.Commands.Admin.Decision.Reject
{
    public class RejectExpenseRequestCommandValidator : AbstractValidator<RejectExpenseRequestCommand>
    {
        public RejectExpenseRequestCommandValidator()
        {
            RuleFor(x => x.ExpenseRequestId)
                  .GreaterThan(0)
                  .WithMessage("Masraf ID değeri pozitif bir sayı olmalıdır.");

            RuleFor(x => x.RejectionReason)
                .NotEmpty()
                .WithMessage("Reddetme sebebi boş bırakılamaz.")
                .MaximumLength(500)
                .WithMessage("Reddetme sebebi en fazla 500 karakter olabilir.");
        }
    }
}
