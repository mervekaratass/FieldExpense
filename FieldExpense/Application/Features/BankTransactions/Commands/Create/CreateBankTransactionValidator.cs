using FluentValidation;

namespace Application.Features.BankTransactions.Commands.Create
{
    public class CreateBankTransactionValidator : AbstractValidator<CreateBankTransactionCommand>
    {
        public CreateBankTransactionValidator()
        {
                RuleFor(x => x.ExpenseRequestId)
                    .GreaterThan(0)
                    .WithMessage("Geçerli bir masraf talebi ID'si girilmelidir.");

                RuleFor(x => x.Amount)
                    .GreaterThan(0)
                    .WithMessage("Tutar 0'dan büyük olmalıdır.");

                RuleFor(x => x.BankReferenceCode)
                    .NotEmpty().WithMessage("Banka referans kodu boş olamaz.")
                    .MaximumLength(100).WithMessage("Banka referans kodu en fazla 100 karakter olabilir.");
            }
    }
}
