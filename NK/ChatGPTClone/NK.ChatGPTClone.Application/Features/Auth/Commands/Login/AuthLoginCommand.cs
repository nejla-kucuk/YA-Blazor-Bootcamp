using MediatR;
using NK.ChatGPTClone.Application.Common.Models.General;
using NK.ChatGPTClone.Application.Common.Models.Identity;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.Login
{
    public class AuthLoginCommand : IRequest<ResponseDto<AuthLoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthLoginCommand(string email, string password)
        {
            Email = email;

            Password = password;
        }

        public IdentityLoginRequest ToIdentityLoginRequest()
        {
            return new IdentityLoginRequest(Email, Password);
        }

        public IdentityAuthenticateRequest ToIdentityAuthenticateRequest()
        {
            return new IdentityAuthenticateRequest(Email, Password);
        }
    }
}