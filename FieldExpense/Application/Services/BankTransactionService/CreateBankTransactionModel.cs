using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BankTransactionService
{
    public  class CreateBankTransactionModel
    {
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
    }
}
