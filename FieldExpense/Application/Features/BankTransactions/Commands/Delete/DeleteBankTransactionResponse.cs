

namespace Application.Features.BankTransactions.Commands.Delete
{
    public class DeleteBankTransactionResponse
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public decimal Amount { get; set; }
        public string BankReferenceCode { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
 
        public int ExpenseRequestId { get; set; }


        // ExpenseRequest bilgisi
       //public string? ExpenseRequestDescription { get; set; }
     

    }
}
