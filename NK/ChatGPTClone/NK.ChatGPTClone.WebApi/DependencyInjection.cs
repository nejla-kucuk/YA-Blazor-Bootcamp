using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.WebApi.Services;

namespace NK.ChatGPTClone.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
