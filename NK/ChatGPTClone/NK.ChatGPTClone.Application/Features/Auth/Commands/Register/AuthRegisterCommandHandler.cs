using MediatR;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.General;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.Register
{
    public class AuthRegisterCommandHandler : IRequestHandler<AuthRegisterCommand, ResponseDto<AuthRegisterDto>>
    {
        private readonly IIdentityService _identityService;


        public AuthRegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<AuthRegisterDto>> Handle(AuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request.ToIdentityRegisterRequest(), cancellationToken);

            return new ResponseDto<AuthRegisterDto>(AuthRegisterDto.Create(response), "User registered successfully.");
        }
    }
}
