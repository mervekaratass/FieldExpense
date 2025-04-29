using Application.Features.Roles.Commands.Create;
using Application.Features.Roles.Commands.Delete;
using Application.Features.Roles.Commands.Update;
using Application.Features.Roles.Queries.GetById;
using Application.Features.Roles.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetListRoleQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdRoleQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRoleCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
