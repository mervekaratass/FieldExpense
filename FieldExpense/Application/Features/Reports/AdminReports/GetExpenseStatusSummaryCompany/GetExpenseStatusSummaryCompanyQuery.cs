using Application.Services.ReportService;
using Core.Application.Pipelines.Authorization;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.AdminReports.GetExpenseStatusSummaryCompany
{
    public class GetExpenseStatusSummaryCompanyQuery : IRequest<List<GetExpenseStatusSummaryCompanyResponse>>,ISecuredRequest
    {
        public DateRangeType DateRangeType { get; set; }
        public ExpenseStatus Status { get; set; }
        public DateTime StartDate { get; set; } // kullanıcı girecek
        public DateTime EndDate { get; set; }   // kullanıcı girecek

        public string[] RequiredRoles => ["Admin"];

        public class GetExpenseStatusSummaryCompanyQueryHandler : IRequestHandler<GetExpenseStatusSummaryCompanyQuery, List<GetExpenseStatusSummaryCompanyResponse>>
        {
            private readonly IReportService _reportService;

            public GetExpenseStatusSummaryCompanyQueryHandler(IReportService reportService)
            {
                _reportService = reportService;
            }

            public async Task<List<GetExpenseStatusSummaryCompanyResponse>> Handle(GetExpenseStatusSummaryCompanyQuery request, CancellationToken cancellationToken)
            {
                return await _reportService.GetExpenseStatusSummaryCompanyAsync(request.DateRangeType, request.Status, request.StartDate, request.EndDate);
            }
        }
    }
}
