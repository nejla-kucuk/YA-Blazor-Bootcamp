using NK.PasswordStorageApp.Domain.Enums;
using NK.PasswordStorageApp.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace NK.PasswordStorageApp.Domain.Dtos
{
    public class AccountCreateDto
    {
        [Required, MinLength(6), MaxLength(25)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(50)]
        public string Password { get; set; }

        [Required, AllowedValues(AccountType.Web, AccountType.Mobile, AccountType.Desktop)]
        public AccountType Type { get; set; }

        public Account ToAccount()
        {
            return new Account
            {
                Id = Ulid.NewUlid().ToGuid(),
                Username = Username,
                Password = Password,
                CreatedOn = DateTime.UtcNow
            };
        }
    }

}
