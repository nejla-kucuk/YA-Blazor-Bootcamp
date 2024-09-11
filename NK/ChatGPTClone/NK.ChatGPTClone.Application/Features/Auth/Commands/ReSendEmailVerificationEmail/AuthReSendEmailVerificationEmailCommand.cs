using MediatR;
using NK.ChatGPTClone.Application.Common.Models.General;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.ReSendEmailVerificationEmail
{
    public class AuthReSendEmailVerificationEmailCommand:IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }

        public AuthReSendEmailVerificationEmailCommand(string email)
        {
            Email = email;
        }
    }
}
