using NK.PasswordStorageApp.Domain.Enums;
using NK.PasswordStorageApp.Domain.Model;


namespace NK.PasswordStorageApp.Domain.Dtos
{
    public class AccountGetAllDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public AccountType Type { get; set; }

        public DateTimeOffset CreatedOn { get; set; }


        public static AccountGetAllDto MapFromAccount(Account account)
        {
            return new AccountGetAllDto
            {
                Id = account.Id,
                Username = account.Username,
                Password = account.Password,
                Type = account.Type,
                CreatedOn = account.CreatedOn
            };
        }
    }
}
