using MediatR;
using NK.ChatGPTClone.Application.Common.Models.General;
using NK.ChatGPTClone.Application.Common.Models.Identity;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.Register
{
    public class AuthRegisterCommand : IRequest<ResponseDto<AuthRegisterDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public IdentityRegisterRequest ToIdentityRegisterRequest()
        {
            return new IdentityRegisterRequest(Email, Password, FirstName, LastName);
        }
    }
}
