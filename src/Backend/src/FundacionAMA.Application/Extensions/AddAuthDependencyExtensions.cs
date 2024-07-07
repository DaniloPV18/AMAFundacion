using FundacionAMA.Application.Services.AuthApp;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FundacionAMA.Application.Extensions
{
    public static class AddAuthDependencyExtensions
    {
        public static void AddAuthDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
        }
    }

}
