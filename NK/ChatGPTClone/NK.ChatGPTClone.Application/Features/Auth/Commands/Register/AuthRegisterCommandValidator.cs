using FluentValidation;
using NK.ChatGPTClone.Application.Common.Interfaces;

namespace NK.ChatGPTClone.Application.Features.Auth.Commands.Register
{
    public class AuthRegisterCommandValidator : AbstractValidator<AuthRegisterCommand>
    {
        private readonly IIdentityService _identityService;

        public AuthRegisterCommandValidator() 
        {
            RuleFor(x => x.Email)
             .NotEmpty()
             .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.FirstName)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
               .MaximumLength(50);

            RuleFor(x => x.Email)
                .MustAsync(CheckEmailExistsAsync)
                .WithMessage("The email is already exists.");

        }

        private async Task<bool> CheckEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return !await _identityService.CheckEmailExistsAsync(email, cancellationToken);
        }

    }
}
