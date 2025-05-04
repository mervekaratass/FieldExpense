using FluentValidation;

namespace Application.Features.ExpenseRequests.Commands.Common.Update
{
    public class UpdateExpenseRequestValidator : AbstractValidator<UpdateExpenseRequestCommand>
    {
        public UpdateExpenseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir masraf ID'si girilmelidir.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Geçerli bir kullanıcı ID'si girilmelidir.");
            RuleFor(x => x.ExpenseCategoryId).GreaterThan(0).WithMessage("Geçerli bir masraf kategorisi ID'si girilmelidir.");
            RuleFor(x => x.PaymentMethodId).GreaterThan(0).WithMessage("Geçerli bir ödeme yöntemi ID'si girilmelidir.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Konum boş olamaz.");
        }
    }
}
