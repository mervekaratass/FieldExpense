using FluentValidation;

namespace Application.Features.BankTransactions.Commands.Delete
{
    public class DeleteBankTransactionValidator : AbstractValidator<DeleteBankTransactionCommand>
    {
        public DeleteBankTransactionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir Banka İşlem ID'si girilmelidir.");
        }
    }
}
