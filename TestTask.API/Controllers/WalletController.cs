using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Commands.Wallet;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create_wallet")]
        public async Task<IActionResult> CreateWallet(CreateWalletCommand command)
        {

            await _mediator.Send(command);
            return Ok("Wallet created successfully");
        }
    }
}
