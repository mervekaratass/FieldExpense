namespace Application.Features.BankTransactions.Commands.Create
{
    public class CreateBankTransactionResponse
    {
        public int Id { get; set; }
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankReferenceCode { get; set; }
        public string TransactionStatus { get; set; }
    }
}
