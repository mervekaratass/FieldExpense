using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Commands.Admin.MarkAsPaid
{

    public class MarkAsPaidCommandValidator : AbstractValidator<MarkAsPaidCommand>
    {
        public MarkAsPaidCommandValidator()
        {
            RuleFor(x => x.ExpenseRequestId).GreaterThan(0).WithMessage("Geçerli bir masraf talep ID'si giriniz.");
        }
    }
}
