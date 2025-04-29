using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    using Application.Features.ExpenseRequests.Commands.Create;
    using Application.Features.ExpenseRequests.Commands.Delete;
    using Application.Features.ExpenseRequests.Commands.Update;
    using Application.Features.ExpenseRequests.Queries.GetById;
    using Application.Features.ExpenseRequests.Queries.GetList;
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
        }
    }

}
