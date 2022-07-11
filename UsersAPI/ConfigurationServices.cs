using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Services.ServicesComponents;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI
{
    public class ConfigurationServices
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<IMailService, MailService>();
        }

    }
}
