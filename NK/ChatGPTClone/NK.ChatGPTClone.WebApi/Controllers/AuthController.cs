using MediatR;
using Microsoft.AspNetCore.Mvc;
using NK.ChatGPTClone.Application.Features.Auth.Commands.Login;
using NK.ChatGPTClone.Application.Features.Auth.Commands.Register;
using NK.ChatGPTClone.Application.Features.Auth.Commands.ReSendEmailVerificationEmail;
using NK.ChatGPTClone.Application.Features.Auth.Commands.VerifyEmail;

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


        [HttpPost("register")]
        public async Task<IActionResult> Register (AuthRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command,cancellationToken));
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail (AuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command,cancellationToken));
        }

        [HttpPost("resend-email-verification")]
        public async Task<IActionResult> ReSendEmailVerificationEmail (AuthReSendEmailVerificationEmailCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command,cancellationToken));
        }
    }
}
