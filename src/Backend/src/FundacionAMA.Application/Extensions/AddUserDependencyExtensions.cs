using FundacionAMA.Application.Services.UserApp;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Services;
using FundacionAMA.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FundacionAMA.Application.Extensions;

public static class AddUserDependencyExtensions
{
    public static void AddUserDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserAppService, UserAppService>();
    }
}
