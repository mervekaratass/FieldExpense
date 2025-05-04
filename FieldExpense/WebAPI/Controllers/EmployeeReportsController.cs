using Application.Features.Reports.EmployeeReports.GetUserExpense;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeReportsController(IMediator mediator)
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

    }
}
