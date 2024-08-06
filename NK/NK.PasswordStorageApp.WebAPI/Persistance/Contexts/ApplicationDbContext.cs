using Microsoft.EntityFrameworkCore;
using NK.PasswordStorageApp.Domain.Model;

namespace NK.PasswordStorageApp.WebAPI.Persistance.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); //Entity config. otomatik olusturur.
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=PasswordStorageApp.db;");
        }
    }
}
