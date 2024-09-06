using MediatR;
using Microsoft.AspNetCore.Mvc;
using NK.ChatGPTClone.Application.Features.Auth.Commands.Login;

namespace NK.ChatGPTClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        public AuthController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (AuthLoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command,cancellationToken));
        }
    }
}
