using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NK.ChatGPTClone.Domain.Entities;
using NK.ChatGPTClone.Domain.Identity;


namespace NK.ChatGPTClone.Persistence.Contexts
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, Role, Guid, AppUserClaim, AppUserRole,AppUserLogin, RoleClaim, AppUserToken>
    {

        public DbSet<ChatSession> ChatSessions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
