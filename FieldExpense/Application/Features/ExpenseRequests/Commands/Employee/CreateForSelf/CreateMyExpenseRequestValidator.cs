﻿using Domain.Entities;
using FluentValidation;


namespace Application.Features.ExpenseRequests.Commands.Employee.CreateForSelf
{

    public class CreateMyExpenseRequestValidator : AbstractValidator<CreateMyExpenseRequestCommand>
    {
        public CreateMyExpenseRequestValidator()
        {
            
            RuleFor(x => x.ExpenseCategoryId).NotEmpty().WithMessage("Masraf kategorisi seçilmelidir.");
            RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Ödeme yöntemi seçilmelidir.");
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Konum bilgisi boş olamaz.");
        }
    }
}
