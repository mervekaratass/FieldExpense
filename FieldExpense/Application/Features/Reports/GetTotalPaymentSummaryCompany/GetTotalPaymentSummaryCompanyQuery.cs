using Application.Services.ReportService;
using Domain.Enums;
using MediatR;

namespace Application.Features.Reports.GetTotalPaymentSummaryCompany
{
    //şirektin günlük,haftalık, aylık total harcaması
    public class GetTotalPaymentSummaryCompanyQuery : IRequest<List<GetTotalPaymentSummaryCompanyResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateRangeType DateRangeType { get; set; } // "Day", "Week", "Month"


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
