using Application.Features.Reports.GetExpenseStatusSummaryCompany;
using Application.Features.Reports.GetTotalPaymentSummaryCompany;
using Application.Features.Reports.GetUserExpense;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("report/my-expense-requests")]
        public async Task<IActionResult> GetMyExpenseRequests()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var result = await _mediator.Send(new GetUserExpenseReportQuery { UserId = userId });
            return Ok(result);
        }

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
    }
}
