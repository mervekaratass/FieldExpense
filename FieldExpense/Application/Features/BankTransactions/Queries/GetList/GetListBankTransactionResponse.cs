using Domain.Enums;

namespace Application.Features.BankTransactions.Queries.GetList
{
    public class GetListBankTransactionResponse
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionStatus { get; set; }
        public string BankReferenceCode { get; set; }
    }
}
