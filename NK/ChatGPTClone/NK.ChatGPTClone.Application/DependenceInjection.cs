using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NK.ChatGPTClone.Application
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(config=>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
