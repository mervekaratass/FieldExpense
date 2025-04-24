using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BankTransaction : Entity
    {
        public int ExpenseRequestId { get; set; }

        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionStatus { get; set; }
        public string BankReferenceCode { get; set; }


        public virtual ExpenseRequest ExpenseRequest { get; set; }
    }



}
