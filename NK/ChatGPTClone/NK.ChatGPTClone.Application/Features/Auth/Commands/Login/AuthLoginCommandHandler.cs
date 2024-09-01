using MediatR;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.General;


namespace NK.ChatGPTClone.Application.Features.Auth.Commands.Login
{
    public class AuthLoginCommandHandler : IRequestHandler<AuthLoginCommand, ResponseDto<AuthLoginDto>>
    {
        private readonly IIdentityService _identityService;

        public AuthLoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<AuthLoginDto>> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.LoginAsync(request.ToIdentityLoginRequest(), cancellationToken);

            return new ResponseDto<AuthLoginDto>(AuthLoginDto.FromIdentityLoginResponse(response));
        }
    }
}
