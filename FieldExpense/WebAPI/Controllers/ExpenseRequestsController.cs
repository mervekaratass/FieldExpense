  
    using Application.Features.ExpenseRequests.Commands.Create;
using Application.Features.ExpenseRequests.Commands.CreateForSelf;
using Application.Features.ExpenseRequests.Commands.Decision.Approve;
    using Application.Features.ExpenseRequests.Commands.Decision.Reject;
    using Application.Features.ExpenseRequests.Commands.Delete;
using Application.Features.ExpenseRequests.Commands.MarkIsPaid;
using Application.Features.ExpenseRequests.Commands.Update;
    using Application.Features.ExpenseRequests.Queries.GetById;
using Application.Features.ExpenseRequests.Queries.GetFiltered;
using Application.Features.ExpenseRequests.Queries.GetList;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

    namespace WebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ExpenseRequestsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public ExpenseRequestsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            public async Task<IActionResult> GetList()
            {
                var result = await _mediator.Send(new GetListExpenseRequestQuery());
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var query = new GetByIdExpenseRequestQuery { Id = id };
                var result = await _mediator.Send(query);
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Add([FromBody] CreateExpenseRequestCommand command)
            {
                var result = await _mediator.Send(command);
                return Created("", result);
            }

            [HttpPut]
            public async Task<IActionResult> Update([FromBody] UpdateExpenseRequestCommand command)
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var command = new DeleteExpenseRequestCommand { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
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

            [HttpPost("create-my")]
            public async Task<IActionResult> CreateMyExpenseRequest([FromBody] CreateMyExpenseRequestCommand command)
            {
                var result = await _mediator.Send(command);
                return Created("", result);
            }


            [HttpGet("mylist")]
            public async Task<IActionResult> GetMyList([FromQuery] GetMyListExpenseRequestQuery query)
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }


        [HttpGet("filtered")]
        public async Task<IActionResult> GetFiltered([FromQuery] DateTime? startDate,  [FromQuery] DateTime? endDate,[FromQuery] int? expenseCategoryId,
                                                      [FromQuery] int? paymentMethodId, [FromQuery] ExpenseStatus? status, [FromQuery] bool? isPaid)
        {     var query = new GetFilteredExpenseRequestQuery
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    ExpenseCategoryId = expenseCategoryId,
                    PaymentMethodId = paymentMethodId,
                    Status = status,
                    IsPaid = isPaid
                };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}

