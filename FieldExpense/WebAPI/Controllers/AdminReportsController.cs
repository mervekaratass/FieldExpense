using Application.Features.Reports.AdminReports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.AdminReports.GetTotalPaymentSummaryCompany;
using Application.Features.Reports.AdminReports.GetUserExpenseIntensitySummaryCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///Şirketin günlük haftalık ve aylık raporlar ile ödeme yoğunluğunu raporlar.
        /// </summary>
        [HttpGet("total-payments")]
        public async Task<IActionResult> GetTotalPaymentSummaryCompany([FromQuery] GetTotalPaymentSummaryCompanyQuery query)
        {

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Şirketin onaylanan veya reddedilen masraflarını belirtilen tarih aralığı ve zaman türüne göre raporlar.
        /// </summary>
        [HttpGet("expense-status-summary")]
        public async Task<IActionResult> GetExpenseStatusSummaryCompany([FromQuery] GetExpenseStatusSummaryCompanyQuery query)
        {

            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpGet("user-expense-intensity-summary")]
        public async Task<IActionResult> GetUserExpenseIntensitySummaryCompany([FromQuery] GetUserExpenseIntensitySummaryCompanyQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
