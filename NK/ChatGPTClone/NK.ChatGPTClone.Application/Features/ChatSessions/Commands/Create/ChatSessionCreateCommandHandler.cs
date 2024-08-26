using MediatR;
using NK.ChatGPTClone.Application.Common.Interfaces;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Commands.Create
{
    public class ChatSessionCreateCommandHandler: IRequestHandler<ChatSessionCreateCommand, Guid>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ChatSessionCreateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(ChatSessionCreateCommand request, CancellationToken cancellationToken)
        {
            var chatSession = request.ToChatSession(_currentUserService.UserId);

            await _context.SaveChangesAsync(cancellationToken);

            return chatSession.Id;
        }
    }
}
