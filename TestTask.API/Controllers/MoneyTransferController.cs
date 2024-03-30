using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Commands.MoneyTransfers;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoneyTransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> TransferMoney(TransferMoneyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
