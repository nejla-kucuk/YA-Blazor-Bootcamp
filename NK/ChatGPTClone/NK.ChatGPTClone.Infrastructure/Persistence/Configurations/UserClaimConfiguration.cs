using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NK.ChatGPTClone.Infrastructure.Identity;

namespace NK.ChatGPTClone.Infrastructure.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("t_userclaims");
        }
    }
}
