using Microsoft.EntityFrameworkCore;
using NK.ChatGPTClone.Domain.Entities;

namespace NK.ChatGPTClone.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ChatSession> ChatSessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
