using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Application.Common.Models.Email;
using Resend;
using System.Web;

namespace NK.ChatGPTClone.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;

        private static string? _emailTemplate;

        public ResendEmailManager(IResend resend, IEnvironmentService environmentService)
        {
            _resend = resend;

            if (string.IsNullOrEmpty(_emailTemplate))
                _emailTemplate = File.ReadAllText(Path.Combine(environmentService.WebRootPath, "email-templates", "email-verification-template.html"));
        }

        public Task EmailVerificationAsync(EmailVerificationDto emailVerificationDto, CancellationToken cancellationToken)
        {
            string html = _emailTemplate;

            var emailTitle = "ChatGPTClone - Email Verification";
            html = html.Replace("{{title}}", emailTitle);
            html = html.Replace("{{greetings}}", $"Hello {emailVerificationDto.Email}!");
            html = html.Replace("{{message}}", "Please verify your email address by clicking the button below:");
            html = html.Replace("{{verifyButtonText}}", "Email Verification");

            var token = HttpUtility.UrlEncode(emailVerificationDto.Token);
            var emailVerificationUrl = $"http://localhost:5207/auth/verify-email?email={emailVerificationDto.Email}&token={token}";
            html = html.Replace("{{verifyButtonLink}}", emailVerificationUrl);

            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(emailVerificationDto.Email);
            message.Subject = emailTitle;
            message.HtmlBody =html;

           return _resend.EmailSendAsync(message);
        }
    }
}
