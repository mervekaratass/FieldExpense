using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Commands.Decision.Approve
{
    public class RejectExpenseRequestCommandValidator : AbstractValidator<ApproveExpenseRequestCommand>
    {
        public RejectExpenseRequestCommandValidator()
        {
            RuleFor(x => x.ExpenseRequestId)
                .GreaterThan(0).WithMessage("Masraf talebi ID'si geçerli olmalıdır.");
        }
    }
}
