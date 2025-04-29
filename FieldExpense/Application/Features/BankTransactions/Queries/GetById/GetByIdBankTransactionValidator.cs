using FluentValidation;

namespace Application.Features.BankTransactions.Queries.GetById
{
    public class GetByIdBankTransactionQueryValidator : AbstractValidator<GetByIdBankTransactionQuery>
    {
        public GetByIdBankTransactionQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz.");
        }
    }

}
