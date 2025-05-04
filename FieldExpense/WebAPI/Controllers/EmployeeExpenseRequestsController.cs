using Application.Features.ExpenseRequests.Commands.Employee.CreateForSelf;
using Application.Features.ExpenseRequests.Queries.Employee.GetFiltered;
using Application.Features.ExpenseRequests.Queries.Employee.GetMyList;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeExpenseRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeExpenseRequestsController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> GetFiltered([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int? expenseCategoryId,
                                                      [FromQuery] int? paymentMethodId, [FromQuery] ExpenseStatus? status, [FromQuery] bool? isPaid)
        {
            var query = new GetFilteredExpenseRequestQuery
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
