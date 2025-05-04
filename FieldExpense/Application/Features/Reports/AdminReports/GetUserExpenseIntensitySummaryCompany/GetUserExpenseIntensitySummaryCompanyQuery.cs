using Application.Services.ReportService;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Reports.AdminReports.GetUserExpenseIntensitySummaryCompany
{
   
    public class GetUserExpenseIntensitySummaryCompanyQuery : IRequest<List<GetUserExpenseIntensitySummaryCompanyResponse>>
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateRangeType DateRangeType { get; set; }

        public class GetUserExpenseIntensitySummaryCompanyQueryHandler : IRequestHandler<GetUserExpenseIntensitySummaryCompanyQuery, List<GetUserExpenseIntensitySummaryCompanyResponse>>
        {
            private readonly IReportService _reportService;

            public GetUserExpenseIntensitySummaryCompanyQueryHandler(IReportService reportService)
            {
                _reportService = reportService;
            }

            public async Task<List<GetUserExpenseIntensitySummaryCompanyResponse>> Handle(GetUserExpenseIntensitySummaryCompanyQuery request, CancellationToken cancellationToken)
            {
                return await _reportService.GetUserExpenseIntensitySummaryCompanyAsync(
                    request.UserId,
                    request.StartDate,
                    request.EndDate,
                    request.DateRangeType
                );
            }
        }
    }

}
