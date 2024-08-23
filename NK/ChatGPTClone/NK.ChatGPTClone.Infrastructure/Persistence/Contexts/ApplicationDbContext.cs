using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Domain.Entities;
using NK.ChatGPTClone.Infrastructure.Identity;


namespace NK.ChatGPTClone.Infrastructure.Contexts
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, Role, Guid, AppUserClaim, AppUserRole,AppUserLogin, RoleClaim, AppUserToken>, IApplicationDbContext
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
