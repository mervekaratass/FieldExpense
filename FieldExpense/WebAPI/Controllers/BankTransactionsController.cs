using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.BankTransactions.Commands.Create;
using Application.Features.BankTransactions.Commands.Delete;
using Application.Features.BankTransactions.Commands.Update;
using Application.Features.BankTransactions.Queries.GetById;
using Application.Features.BankTransactions.Queries.GetList;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankTransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBankTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListBankTransactionQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdBankTransactionQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteBankTransactionCommand command = new() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBankTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

