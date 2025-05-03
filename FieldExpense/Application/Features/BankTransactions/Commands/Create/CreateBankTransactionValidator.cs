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

               
            }
    }
}
