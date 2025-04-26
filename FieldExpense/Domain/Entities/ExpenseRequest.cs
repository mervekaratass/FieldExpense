using Core.Persistence;
using Domain.Enums;

namespace Domain.Entities
{
    public class ExpenseRequest : Entity<int>
    {
        public int UserId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }
        public ExpenseStatus Status { get; set; } //  (Pending, Approved, Rejected)
        public string? RejectionReason { get; set; }
        public bool IsPaid { get; set; }


        public virtual User User { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual BankTransaction? BankTransaction { get; set; }
    }

}
