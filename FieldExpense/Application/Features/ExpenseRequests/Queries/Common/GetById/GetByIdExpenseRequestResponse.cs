namespace Application.Features.ExpenseRequests.Queries.Common.GetById
{
    public class GetByIdExpenseRequestResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }

        public string Status { get; set; }
        public bool IsPaid { get; set; }
        public string? RejectionReason { get; set; }
    }
}
