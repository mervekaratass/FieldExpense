using Application.Features.ExpenseCategories.Commands.Create;
using Application.Features.ExpenseCategories.Commands.Delete;
using Application.Features.ExpenseCategories.Commands.Update;
using Application.Features.ExpenseCategories.Queries.GetById;
using Application.Features.ExpenseCategories.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateExpenseCategoryCommand command)
        {
            var result= await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListExpenseCategoryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdExpenseCategoryQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteExpenseCategoryCommand command = new() { Id = id };
           var result= await _mediator.Send(command);
            return Ok(result); 
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExpenseCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
