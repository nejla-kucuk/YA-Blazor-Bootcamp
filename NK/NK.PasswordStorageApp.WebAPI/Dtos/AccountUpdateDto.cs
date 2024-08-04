using NK.PasswordStorageApp.WebAPI.Model;

namespace NK.PasswordStorageApp.WebAPI.Dtos
{
    public class AccountUpdateDto
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Account ToAccount(Account account)
        {
            account.Username = Username;
            account.Password = Password;

            return account;
        }
    }
}
