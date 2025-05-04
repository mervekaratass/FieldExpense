using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Ok(response);
        }

        [HttpPut("update-password")]
     
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
