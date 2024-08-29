using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NK.ChatGPTClone.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;


namespace NK.ChatGPTClone.Infrastructure.Persistence.Seaders
{
    public class UserSeader : IEntityTypeConfiguration<AppUser>
    {

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
                var initialUserId = Guid.Parse("2798212b-3e5d-4556-8629-a64eb70da4a8");

                var initialUser = new AppUser
                {
                    Id = initialUserId,
                    UserName = "nejla",
                    NormalizedUserName = "NEJLA",
                    Email = "nejla@gmail.com",
                    NormalizedEmail = "NEJLA@GMAIL.COM",
                    EmailConfirmed = true,
                    CreatedByUserId = initialUserId.ToString(),
                    CreatedOn = new DateTimeOffset(new DateTime(2024, 08, 28)),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    FirstName = "Nejla",
                    LastName = "Kucuk",
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                };

                initialUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(initialUser, "1234nejla");

                builder.HasData(initialUser);
        }

    }
}

