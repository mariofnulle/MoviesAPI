using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MoviesAPI.Components;
using MoviesAPI.CustomAuthorization;
using MoviesAPI.Interfaces;
using MoviesAPI.Services.ServicesComponents;
using MoviesAPI.Services.ServicesInterfaces;

namespace MoviesAPI
{
    public class ConfigurationServices
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IMovie, MovieComponent>();
            services.AddScoped<IMovieService, MovieService>();
            
            services.AddScoped<IMovieTheather, MovieTheatherComponent>();
            services.AddScoped<IMovieTheatherService, MovieTheatherService>();

            services.AddScoped<IAddress, AddressComponent>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IManager, ManagerComponent>();
            services.AddScoped<IManagerService, ManagerService>();

            services.AddScoped<ISession, SessionComponent>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
        }
    }
}
