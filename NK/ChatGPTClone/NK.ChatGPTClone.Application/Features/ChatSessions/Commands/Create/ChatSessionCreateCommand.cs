using MediatR;
using NK.ChatGPTClone.Application.Common.Models.General;
using NK.ChatGPTClone.Domain.Entities;
using NK.ChatGPTClone.Domain.Enums;
using NK.ChatGPTClone.Domain.ValueObjects;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Commands.Create
{
    public class ChatSessionCreateCommand:IRequest<ResponseDto<Guid>>
    {
        public GptModelType Model { get; set; }

        public string Content { get; set; }

        public ChatSession ToChatSession(Guid userId)
        {
            return new ChatSession
            {
              Id = Ulid.NewUlid().ToGuid(), // IIDService.NewId(), Guid.V7.NewGuid()
              Model = Model,
              AppUserId = userId,
              CreatedOn = DateTimeOffset.UtcNow,
              CreatedByUserId= userId.ToString(),
              Title = Content.Length > 50 ? Content.Substring(0, 50) : Content,
              Threads =
              [
                    new ChatThread()
                    {
                        Id = Ulid.NewUlid().ToString(),
                        CreatedOn = DateTimeOffset.UtcNow,
                        Messages =
                        [
                            new ChatMessage()
                            {
                                Id = Ulid.NewUlid().ToString(),
                                Model = Model,
                                Type = ChatMessageType.System,
                                Content = "You're a very helpful and happy assistant which loves to help people.",
                                CreatedOn = DateTimeOffset.UtcNow
                            },
                            new ChatMessage()
                            {
                                Id = Ulid.NewUlid().ToString(),
                                Model = Model,
                                Type = ChatMessageType.User,
                                Content = Content,
                                CreatedOn = DateTimeOffset.UtcNow
                            }
                        ]
                    },
              ]
            };
        }
    }
}
