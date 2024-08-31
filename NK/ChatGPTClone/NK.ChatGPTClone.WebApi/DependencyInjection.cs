using Microsoft.AspNetCore.Localization;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.WebApi.Services;
using System.Globalization;

namespace NK.ChatGPTClone.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            //Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Set the default culture
                var defaultCulture = new CultureInfo("en-US");

                // Set supported cultures
                var supportedCultures = new List<CultureInfo>
                {
                    defaultCulture,
                    new CultureInfo("tr-TR")
                };

                // Add supported cultures
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.ApplyCurrentCultureToResponseHeaders = true;
                
            });

            return services;
        }
    }
}
