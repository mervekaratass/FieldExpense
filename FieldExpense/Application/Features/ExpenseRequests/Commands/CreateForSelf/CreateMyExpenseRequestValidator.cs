using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Commands.CreateForSelf
{
  
    public class CreateMyExpenseRequestValidator : AbstractValidator<ExpenseRequest>
    {
        public CreateMyExpenseRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı seçilmelidir.");
            RuleFor(x => x.ExpenseCategoryId).NotEmpty().WithMessage("Masraf kategorisi seçilmelidir.");
            RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Ödeme yöntemi seçilmelidir.");
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Konum bilgisi boş olamaz.");
        }
    }
}
