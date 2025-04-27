using Application.Features.ExpenseCategories.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentMethods.Commands.Delete
{
    public class DeletePaymentMethodValidator : AbstractValidator<DeletePaymentMethodCommand>
    {
        public DeletePaymentMethodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir ödeme yöntemi ID'si girilmelidir.");
        }
    }
}
