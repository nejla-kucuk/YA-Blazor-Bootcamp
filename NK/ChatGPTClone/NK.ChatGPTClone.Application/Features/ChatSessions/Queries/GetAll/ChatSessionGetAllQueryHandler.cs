using MediatR;
using Microsoft.EntityFrameworkCore;
using NK.ChatGPTClone.Application.Common.Interfaces;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Queries.GetAll
{
   public class ChatSessionGetAllQueryHandler : IRequestHandler<ChatSessionGetAllQuery, List<ChatSessionGetAllDto>>
   {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ChatSessionGetAllQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public Task<List<ChatSessionGetAllDto>> Handle(ChatSessionGetAllQuery request, CancellationToken cancellationToken)
        {
            return _context
                .ChatSessions
                .AsNoTracking()
                .Where(x => x.AppUserId == _currentUserService.UserId)
                .OrderByDescending(cs => cs.CreatedOn)
                .Select(x => ChatSessionGetAllDto.MapFromChatSession(x))
                .ToListAsync(cancellationToken);
        }
    }
}
