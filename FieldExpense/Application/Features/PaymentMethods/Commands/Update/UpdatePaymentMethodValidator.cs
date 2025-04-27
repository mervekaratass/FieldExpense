using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PaymentMethods.Commands.Update
{
    public class UpdatePaymentMethodValidator : AbstractValidator<PaymentMethod>
    {
        public UpdatePaymentMethodValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Ödeme yöntemi ID'si boş olamaz.")
              .GreaterThan(0).WithMessage("Geçerli bir ödeme yöntemi ID'si girilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ödeme yöntemi adı boş olamaz.")
                .MinimumLength(2).WithMessage("Ödeme yöntemi adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ödeme yöntemi adı en fazla 100 karakter olabilir.");
        }
    }
}
