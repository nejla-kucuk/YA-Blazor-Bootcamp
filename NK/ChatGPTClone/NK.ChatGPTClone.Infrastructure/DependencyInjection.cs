using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Infrastructure.Contexts;


namespace NK.ChatGPTClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


            return services;
        }
    }
}
