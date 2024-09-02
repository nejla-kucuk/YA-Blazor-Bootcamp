using FluentValidation;
using Microsoft.Extensions.Localization;
using NK.ChatGPTClone.Application.Common.Localization;

namespace NK.ChatGPTClone.Application.Features.ChatSessions.Commands.Create
{
    public class ChatSessionCreateCommandValidator:AbstractValidator<ChatSessionCreateCommand>
    {

        public ChatSessionCreateCommandValidator(IStringLocalizer <CommonLocalization> localizer) 
        {
            RuleFor(x => x.Model)
                .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Model)])
                .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid, nameof(x.Model)]);


            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Content)])
                .Length(5,4000).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween, nameof(x.Content),5,4000]);

        }

    }
}
