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

            return Guid.Parse("2798212b-3e5d-4556-8629-a64eb70da4a8");
        }
    }
}
