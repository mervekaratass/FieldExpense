﻿using Core.Persistence;
using Domain.Enums;


namespace Domain.Entities
{
    public class BankTransaction : Entity<int>
    {
        public int ExpenseRequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string BankReferenceCode { get; set; }

        public virtual ExpenseRequest ExpenseRequest { get; set; }
    }



}
