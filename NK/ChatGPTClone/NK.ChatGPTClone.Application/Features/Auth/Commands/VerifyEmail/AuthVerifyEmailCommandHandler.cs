using MediatR;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.General;
using NK.ChatGPTClone.Application.Common.Models.Identity;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.VerifyEmail
{

    public class AuthVerifyEmailCommandHandler : IRequestHandler<AuthVerifyEmailCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;

        public AuthVerifyEmailCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<string>> Handle(AuthVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.VerifyEmailAsync(new IdentityVerifyEmailRequest(request.Email, request.Token), cancellationToken);

            return new ResponseDto<string>(data: response.Email, message: "Email verified successfully.");
        }
    }
}
