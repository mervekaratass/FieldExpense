

namespace Application.Features.BankTransactions.Commands.Update
{
    public class UpdateBankTransactionResponse
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankReferenceCode { get; set; }
    }
}
