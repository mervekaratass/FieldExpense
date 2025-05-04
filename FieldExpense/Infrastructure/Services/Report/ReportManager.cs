using Application.Features.Reports;
using Application.Features.Reports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.GetTotalPaymentSummaryCompany;
using Application.Services.ReportService;
using Dapper;
using Domain.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Infrastructure.Services.Report
{
    public class ReportManager:IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<GetUserExpenseReportResponse>> GetExpenseRequestsByUserIdAsync(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MsSqlConnectionString"));

            string query = @"SELECT * FROM V_ExpenseRequestDetails WHERE UserId = @UserId";

            var result = await connection.QueryAsync<GetUserExpenseReportResponse>(query, new { UserId = userId });

            return result.ToList();
        }

        public async Task<List<GetTotalPaymentSummaryCompanyResponse>> GetTotalPaymentSummaryCompanyAsync(DateTime startDate, DateTime endDate, DateRangeType type)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MsSqlConnectionString"));

            var result = await connection.QueryAsync<GetTotalPaymentSummaryCompanyResponse>(
                "sp_TotalPaymentsFlexible",
                new { StartDate = startDate, EndDate = endDate, DateRangeType = (int)type },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<GetExpenseStatusSummaryCompanyResponse>> GetExpenseStatusSummaryCompanyAsync(DateRangeType dateRangeType, ExpenseStatus status, DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MsSqlConnectionString"));

            var parameters = new DynamicParameters();
            parameters.Add("@DateRangeType", dateRangeType);
            parameters.Add("@Status", status);
            parameters.Add("@StartDate", startDate);
            parameters.Add("@EndDate", endDate);

            var result = await connection.QueryAsync<GetExpenseStatusSummaryCompanyResponse>(
                "sp_GetExpenseStatusSummaryCompany",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


    }
}
