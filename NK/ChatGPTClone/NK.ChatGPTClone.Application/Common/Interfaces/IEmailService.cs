﻿using NK.ChatGPTClone.Application.Common.Models.Email;

namespace NK.ChatGPTClone.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task EmailVerificationAsync(EmailVerificationDto emailVerificationDto, CancellationToken cancellationToken);
    }
}
