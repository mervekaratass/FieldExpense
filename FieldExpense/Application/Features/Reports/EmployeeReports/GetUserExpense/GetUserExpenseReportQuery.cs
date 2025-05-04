using Application.Services.ReportService;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Reports.EmployeeReports.GetUserExpense
{
    //personelin kendine ait masraf talepleri ve detayları 
    public class GetUserExpenseReportQuery : IRequest<List<GetUserExpenseReportResponse>>, ISecuredRequest
    {
        public int UserId { get; set; }
        public string[] RequiredRoles => ["Personel"];

        public class GetUserExpenseReportQueryHandler : IRequestHandler<GetUserExpenseReportQuery, List<GetUserExpenseReportResponse>>
        {
            private readonly IReportService _reportService;

            public GetUserExpenseReportQueryHandler(IReportService reportService)
            {
                _reportService = reportService;
            }

            public async Task<List<GetUserExpenseReportResponse>> Handle(GetUserExpenseReportQuery request, CancellationToken cancellationToken)
            {
                return await _reportService.GetExpenseRequestsByUserIdAsync(request.UserId);
            }
        }

    }

}
