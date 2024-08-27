using NK.ChatGPTClone.Application.Common.Interfaces;
using System.Security.Claims;

namespace NK.ChatGPTClone.WebApi.Services
{
    public class CurrentUserManager : ICurrentUserService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId { get; set; }

        private Guid GetUserId()
        {
            var userId = _httpContextAccessor
                         .HttpContext?
                         .User?
                         .FindFirstValue("uid");
            
            return string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
        }
    }
}
