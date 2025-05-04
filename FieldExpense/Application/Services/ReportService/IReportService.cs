using Application.Features.Reports.AdminReports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.AdminReports.GetTotalPaymentSummaryCompany;
using Application.Features.Reports.AdminReports.GetUserExpenseIntensitySummaryCompany;
using Application.Features.Reports.EmployeeReports.GetUserExpense;
using Domain.Enums;


namespace Application.Services.ReportService
{
    public interface IReportService
    {
        Task<List<GetUserExpenseReportResponse>> GetExpenseRequestsByUserIdAsync(int userId);
        Task<List<GetTotalPaymentSummaryCompanyResponse>> GetTotalPaymentSummaryCompanyAsync(DateTime startDate, DateTime endDate, DateRangeType type);
        Task<List<GetExpenseStatusSummaryCompanyResponse>> GetExpenseStatusSummaryCompanyAsync(DateRangeType dateRangeType, ExpenseStatus status, DateTime startDate, DateTime endDate);
        Task<List<GetUserExpenseIntensitySummaryCompanyResponse>> GetUserExpenseIntensitySummaryCompanyAsync(int userId, DateTime startDate, DateTime endDate, DateRangeType type);



    }
}
