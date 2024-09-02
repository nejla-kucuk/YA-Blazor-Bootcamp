using Microsoft.AspNetCore.Identity;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.Identity;
using NK.ChatGPTClone.Application.Common.Models.Jwt;
using NK.ChatGPTClone.Infrastructure.Identity;

namespace NK.ChatGPTClone.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtService;

        public IdentityManager(UserManager<AppUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<bool> AuthenticateAsync(IdentityAuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null) return false;

            return await _userManager.CheckPasswordAsync(user, request.Password);
        }

        public async Task<IdentityLoginResponse> LoginAsync(IdentityLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var roles = await _userManager.GetRolesAsync(user);

            var jwtRequest = new JwtGenerateTokenRequest(user.Id, user.Email, roles);

            var jwtResponse = _jwtService.GenerateToken(jwtRequest);

            return new IdentityLoginResponse(jwtResponse.Token, jwtResponse.ExpiresAt);
        }
    }
}
