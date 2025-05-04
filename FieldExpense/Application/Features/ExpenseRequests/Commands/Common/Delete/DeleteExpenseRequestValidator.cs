using FluentValidation;

namespace Application.Features.ExpenseRequests.Commands.Common.Delete
{
    public class DeleteExpenseRequestValidator : AbstractValidator<DeleteExpenseRequestCommand>
    {
        public DeleteExpenseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir masraf id si girilmelidir.");


        }
    }
}
