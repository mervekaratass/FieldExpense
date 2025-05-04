using Application.Services.ReportService;
using Core.Application.Pipelines.Authorization;
using Domain.Enums;
using MediatR;

namespace Application.Features.Reports.AdminReports.GetTotalPaymentSummaryCompany
{
    //şirektin günlük,haftalık, aylık total harcaması
    public class GetTotalPaymentSummaryCompanyQuery : IRequest<List<GetTotalPaymentSummaryCompanyResponse>>,ISecuredRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateRangeType DateRangeType { get; set; } // "Day", "Week", "Month"

        public string[] RequiredRoles => ["Admin"];

        public class GetTotalPaymentQueryHandler : IRequestHandler<GetTotalPaymentSummaryCompanyQuery, List<GetTotalPaymentSummaryCompanyResponse>>
        {
            private readonly IReportService _reportService;

            public GetTotalPaymentQueryHandler(IReportService reportService)
            {
                _reportService = reportService;
            }

            public async Task<List<GetTotalPaymentSummaryCompanyResponse>> Handle(GetTotalPaymentSummaryCompanyQuery request, CancellationToken cancellationToken)
            {
                return await _reportService.GetTotalPaymentSummaryCompanyAsync(request.StartDate, request.EndDate, request.DateRangeType);
            }
        }

    }
}
