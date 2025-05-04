using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.EmployeeReports.GetUserExpense
{
    public class GetUserExpenseReportResponse
    {
        public int ExpenseRequestId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ExpenseCategory { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string? RejectionReason { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedDate { get; set; }

    }

}
