using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Commands.MarkAsPaid
{
    public class MarkAsPaidResponse
    {
        public int Id { get; set; }
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankReferenceCode { get; set; }
    }
}
