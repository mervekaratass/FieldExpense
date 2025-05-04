using Application.Features.Reports;
using Application.Features.Reports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.GetTotalPaymentSummaryCompany;
using Domain.Enums;


namespace Application.Services.ReportService
{
    public interface IReportService
    {
        Task<List<GetUserExpenseReportResponse>> GetExpenseRequestsByUserIdAsync(int userId);
        Task<List<GetTotalPaymentSummaryCompanyResponse>> GetTotalPaymentSummaryCompanyAsync(DateTime startDate, DateTime endDate, DateRangeType type);
        Task<List<GetExpenseStatusSummaryCompanyResponse>> GetExpenseStatusSummaryCompanyAsync(DateRangeType dateRangeType, ExpenseStatus status, DateTime startDate, DateTime endDate);



    }
}
