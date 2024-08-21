using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Domain.Entities;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Commands
{
    public class ChatSessionSession
    {
        public readonly IApplicationDbContext _applicationDbContext;

        public ChatSessionSession(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateChatSessionAsync(ChatSession chatSession, CancellationToken cancellationToken)
        {
            _applicationDbContext.ChatSessions.Add(chatSession);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
