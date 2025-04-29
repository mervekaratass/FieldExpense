
using Domain.Enums;

namespace Application.Features.BankTransactions.Queries.GetById
{
    public class GetByIdBankTransactionResponse
    {
        public int Id { get; set; }
        public string UserFullName { get; set; } // ExpenseRequest.User.FirstName + LastName
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string BankReferenceCode { get; set; }
    }

}
