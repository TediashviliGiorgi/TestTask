using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Commands.Users;

namespace TestTask.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create_user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete_user")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { UserId = id });
            return Ok(result);
        }
    }
}
