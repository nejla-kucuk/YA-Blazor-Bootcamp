using NK.PasswordStorageApp.Domain.Enums;
using NK.PasswordStorageApp.Domain.Model;


namespace NK.PasswordStorageApp.Domain.Dtos
{
    public class AccountUpdateDto
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public AccountType Type { get; set; }


        public Account ToAccount(Account account)
        {
            account.Username = Username;
            account.Password = Password;
            account.Type = Type;
            account.ModifiedOn = DateTimeOffset.UtcNow;

            return account;
        }
    }
}
