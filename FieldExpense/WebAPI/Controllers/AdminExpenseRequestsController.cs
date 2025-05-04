using Application.Features.ExpenseRequests.Commands.Admin.Decision.Approve;
using Application.Features.ExpenseRequests.Commands.Admin.Decision.Reject;
using Application.Features.ExpenseRequests.Commands.Admin.MarkAsPaid;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminExpenseRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminExpenseRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var command = new ApproveExpenseRequestCommand { ExpenseRequestId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id, [FromBody] RejectExpenseRequestCommand command)
        {
            if (id != command.ExpenseRequestId)
                return BadRequest("URL'deki ID ile body'deki ID eşleşmiyor.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("mark-as-paid/{id}")]
        public async Task<IActionResult> MarkAsPaid([FromRoute] int id)
        {
            var command = new MarkAsPaidCommand { ExpenseRequestId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
