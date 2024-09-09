namespace NK.ChatGPTClone.Application.Common.Models.Identity
{
    public class IdentityRegisterResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string EmailToken { get; set; }

        public IdentityRegisterResponse(Guid id, string emailToken, string email)
        {
            EmailToken = emailToken;
            Id = id;
            Email = email;
        }
    }
}
