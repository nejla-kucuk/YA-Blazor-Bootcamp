using Microsoft.EntityFrameworkCore;
using NK.PasswordStorageApp.Domain.Enums;
using NK.PasswordStorageApp.Domain.Model;


namespace NK.PasswordStorageApp.WebAPI.Persistance.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Account> builder)
        {
            //ID --> Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd(); // ID+1


            //Username
            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasIndex(x => x.Username); //for search


            //Password
            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(50);

            //Type
            builder.Property(x => x.Type)
                .HasConversion<int>()
                .HasDefaultValue(AccountType.Web)
                .IsRequired();

            //CreatedOn
            builder.Property(x => x.CreatedOn)
                   .IsRequired();

            //ModifiedOn
            builder.Property(x => x.ModifiedOn)
                 .IsRequired(false);

            //TableName
            builder.ToTable("t_account");
        }
    }
}
