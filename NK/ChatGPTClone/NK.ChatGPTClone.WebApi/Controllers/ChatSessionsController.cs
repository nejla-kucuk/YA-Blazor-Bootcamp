using MediatR;
using Microsoft.AspNetCore.Mvc;
using NK.ChatGPTClone.Application.Features.ChatSessions.Commands.Create;
using NK.ChatGPTClone.Application.Features.ChatSessions.Queries.GetAll;
using NK.ChatGPTClone.Application.Features.ChatSessions.Queries.GetById;

namespace NK.ChatGPTClone.WebApi.Controllers
{
    public class ChatSessionsController : ApiControllerBase
    {
        public ChatSessionsController(ISender mediatr): base(mediatr)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
          
            return Ok(await Mediatr.Send(new ChatSessionGetAllQuery(),cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(new ChatSessionGetByIdQuery(id), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ChatSessionCreateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command, cancellationToken));
        }

    }
}
