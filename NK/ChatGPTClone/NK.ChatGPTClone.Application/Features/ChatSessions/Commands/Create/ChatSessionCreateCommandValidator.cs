using FluentValidation;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Commands.Create
{
    public class ChatSessionCreateCommandValidator:AbstractValidator<ChatSessionCreateCommand>
    {

        public ChatSessionCreateCommandValidator() 
        {
            RuleFor(x => x.Model)
                .NotNull()
                .WithMessage("Model is required")
                .NotEmpty()
                .WithMessage("Model is required")
                .IsInEnum()
                .WithMessage("Model is invalid");


            RuleFor(x => x.Content)
                .NotNull()
                .WithMessage("Content is required")
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(4000)
                .WithMessage("Content must not exceed 500 characters")
                .MinimumLength(5)
                .WithMessage("Content must be at least 5 characters."); ;

        }

    }
}
