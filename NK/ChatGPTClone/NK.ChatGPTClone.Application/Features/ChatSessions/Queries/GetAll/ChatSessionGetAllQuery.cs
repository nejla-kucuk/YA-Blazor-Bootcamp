using MediatR;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Queries.GetAll
{
    public class ChatSessionGetAllQuery: IRequest<List<ChatSessionGetAllDto>>
    {
    }
}
