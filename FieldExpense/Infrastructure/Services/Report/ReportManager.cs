using Application.Features.Reports.AdminReports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.AdminReports.GetTotalPaymentSummaryCompany;
using Application.Features.Reports.AdminReports.GetUserExpenseIntensitySummaryCompany;
using Application.Features.Reports.EmployeeReports.GetUserExpense;
using Application.Services.ReportService;
using Azure.Core;
using Dapper;
using Domain.Enums;
using Infrastructure.Contexts;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Infrastructure.Services.Report
{
    public class ReportManager:IReportService
    {
        private readonly IDbConnection _connection;

        public ReportManager(DapperContext context)
        {
            _connection = context.CreateConnection();
        }

      
        public async Task<List<GetUserExpenseReportResponse>> GetExpenseRequestsByUserIdAsync(int userId)
        {
            string query = @"SELECT * FROM V_ExpenseRequestDetails WHERE UserId = @UserId";
            var result = await _connection.QueryAsync<GetUserExpenseReportResponse>(query, new { UserId = userId });
            return result.ToList();
        }

        public async Task<List<GetTotalPaymentSummaryCompanyResponse>> GetTotalPaymentSummaryCompanyAsync(DateTime startDate, DateTime endDate, DateRangeType type)
        {
          

            var result = await _connection.QueryAsync<GetTotalPaymentSummaryCompanyResponse>(
                "sp_TotalPaymentsFlexible",
                new { StartDate = startDate, EndDate = endDate, DateRangeType = (int)type },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<GetExpenseStatusSummaryCompanyResponse>> GetExpenseStatusSummaryCompanyAsync(DateRangeType dateRangeType, ExpenseStatus status, DateTime startDate, DateTime endDate)
        {
          

            var parameters = new DynamicParameters();
            parameters.Add("@DateRangeType", dateRangeType);
            parameters.Add("@Status", status);
            parameters.Add("@StartDate", startDate);
            parameters.Add("@EndDate", endDate);

            var result = await _connection.QueryAsync<GetExpenseStatusSummaryCompanyResponse>(
                "sp_GetExpenseStatusSummaryCompany",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<GetUserExpenseIntensitySummaryCompanyResponse>> GetUserExpenseIntensitySummaryCompanyAsync(int userId, DateTime startDate, DateTime endDate, DateRangeType type)
        {
            var result = await _connection.QueryAsync<GetUserExpenseIntensitySummaryCompanyResponse>(
                "sp_GetUserExpenseIntensitySummaryCompany",
                new { UserId = userId, StartDate = startDate, EndDate = endDate, DateRangeType = (int)type },
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }





    }
}
