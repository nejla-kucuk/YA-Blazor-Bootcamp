using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NK.ChatGPTClone.Application.Common.Behaviours;
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

                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
