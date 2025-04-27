using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentMethods.Commands.Create
{
    public class CreatePaymentMethodValidator : AbstractValidator<CreatePaymentMethodCommand>
    {
        public CreatePaymentMethodValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ödeme yöntemi adı boş olamaz.")
                .MinimumLength(2).WithMessage("Ödeme yöntemi adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ödeme yöntemi adı en fazla 100 karakter olabilir.");
        }
    }
}
