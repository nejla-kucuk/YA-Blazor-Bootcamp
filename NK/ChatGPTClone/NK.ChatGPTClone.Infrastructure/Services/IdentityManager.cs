using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.Identity;
using NK.ChatGPTClone.Application.Common.Models.Jwt;
using NK.ChatGPTClone.Infrastructure.Identity;
using FluentValidation;
using FluentValidation.Results;

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

        public Task<bool> CheckEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return _userManager
                        .Users
                        .AnyAsync(x=> x.Email == email, cancellationToken);
        }

        public async Task<IdentityLoginResponse> LoginAsync(IdentityLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var roles = await _userManager.GetRolesAsync(user);

            var jwtRequest = new JwtGenerateTokenRequest(user.Id, user.Email, roles);

            var jwtResponse = _jwtService.GenerateToken(jwtRequest);

            return new IdentityLoginResponse(jwtResponse.Token, jwtResponse.ExpiresAt);
        }

        public async Task<IdentityRegisterResponse> RegisterAsync(IdentityRegisterRequest request, CancellationToken cancellationToken)
        {
             var userId = Ulid.NewUlid().ToGuid();

             var user = new AppUser
             {
                 Id = userId,
                 Email = request.Email,
                 UserName = request.Email,
                 FirstName = request.FirstName,
                 LastName = request.LastName,
                 CreatedByUserId = userId.ToString(),
                 CreatedOn = DateTimeOffset.UtcNow,
                 EmailConfirmed = false
             };

             var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) CreateAndThrowValidationException(result.Errors);
            
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return new IdentityRegisterResponse(userId, emailToken, user.Email);
        }

        private void CreateAndThrowValidationException(IEnumerable<IdentityError> errors)
        {

            var errorMessages = errors
            .Select(x => new ValidationFailure(x.Code, x.Description))
            .ToArray();


            throw new ValidationException(errorMessages);
        }
    }
}


    
