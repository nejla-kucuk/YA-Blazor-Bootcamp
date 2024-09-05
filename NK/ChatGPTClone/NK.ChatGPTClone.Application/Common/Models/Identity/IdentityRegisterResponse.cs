namespace NK.ChatGPTClone.Application.Common.Models.Identity
{
    public class IdentityRegisterResponse
    {
        public Guid Id { get; set; }
        public string EmailToken { get; set; }

        public IdentityRegisterResponse(Guid id, string emailToken)
        {
            EmailToken = emailToken;
            Id = id;
        }
    }
}
