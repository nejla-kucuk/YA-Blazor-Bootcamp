﻿using NK.ChatGPTClone.Application.Common.Models.Identity;

namespace NK.ChatGPTClone.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> AuthenticateAsync(IdentityAuthenticateRequest request, CancellationToken cancellationToken);
        
        Task<IdentityLoginResponse> LoginAsync(IdentityLoginRequest request, CancellationToken cancellationToken);

        Task<bool> CheckEmailExistsAsync(string email, CancellationToken cancellationToken);

        Task<IdentityRegisterResponse> RegisterAsync(IdentityRegisterRequest request, CancellationToken cancellationToken);

    }
}
