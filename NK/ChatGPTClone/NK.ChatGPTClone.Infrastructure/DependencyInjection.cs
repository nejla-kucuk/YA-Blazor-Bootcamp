using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NK.ChatGPTClone.Application.Common.Interfaces;
using NK.ChatGPTClone.Domain.Settings;
using NK.ChatGPTClone.Infrastructure.Contexts;
using NK.ChatGPTClone.Infrastructure.Identity;
using NK.ChatGPTClone.Infrastructure.Services;


namespace NK.ChatGPTClone.Infrastructure
{
    // Bu sınıf, uygulama altyapısının bağımlılık enjeksiyonunu yapılandırır
    public static class DependencyInjection
    {
        // Bu metod, altyapı servislerini IServiceCollection'a ekler
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Veritabanı bağlantı dizesini yapılandırmadan alır
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // ApplicationDbContext'i PostgreSQL ile kullanmak üzere yapılandırır
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

            // IApplicationDbContext'i ApplicationDbContext ile eşler
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            // JWT ayarlarını yapılandırır
            ConfigureJwtSettings(services, configuration);

            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped<IIdentityService, IdentityManager>();

            services.AddIdentity<AppUser,Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            return services;
        }

        // JWT ayarlarını yapılandıran özel metod
        private static void ConfigureJwtSettings(IServiceCollection services, IConfiguration configuration)
        {
            // Yapılandırmadan JWT ayarları bölümünü alır
            var jwtSettingsSection = configuration.GetSection("JwtSettings");

            // Eğer JWT ayarları yapılandırmada mevcutsa, bu ayarları kullanır
            if (jwtSettingsSection.Exists())
            {
                services.Configure<JwtSettings>(jwtSettingsSection);
            }
            // Aksi takdirde, varsayılan değerlerle JWT ayarlarını yapılandırır
            else
            {
                services.Configure<JwtSettings>(options =>
                {
                    options.SecretKey = "default-secret-key-for-development-only";
                    options.AccessTokenExpiration = TimeSpan.FromMinutes(30);
                    options.RefreshTokenExpiration = TimeSpan.FromDays(7);
                    options.Issuer = "ChatGPTClone";
                    options.Audience = "ChatGPTClone";
                });
            }
        }
    }
}
