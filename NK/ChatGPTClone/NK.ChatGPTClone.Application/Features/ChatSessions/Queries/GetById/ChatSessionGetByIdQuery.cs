using MediatR;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Queries.GetById
{
    public class ChatSessionGetByIdQuery: IRequest<ChatSessionGetByIdDto>
    {
        public Guid Id { get; set; }

        public ChatSessionGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }


}
