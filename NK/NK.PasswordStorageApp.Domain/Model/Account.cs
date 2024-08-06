using NK.PasswordStorageApp.Domain.Enums;

namespace NK.PasswordStorageApp.Domain.Model
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Username { get; set;}

        public string Password { get; set;}

        public AccountType Type { get; set;}

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
