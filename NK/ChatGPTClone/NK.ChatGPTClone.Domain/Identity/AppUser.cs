using Microsoft.AspNetCore.Identity;
using NK.ChatGPTClone.Domain.Common;
using NK.ChatGPTClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.ChatGPTClone.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntity, ICreatedByEntity, IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<ChatSession> ChatSession { get; set; }
    }
}
