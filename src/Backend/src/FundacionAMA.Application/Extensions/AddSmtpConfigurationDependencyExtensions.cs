using FundacionAMA.Application.Services.SmtpConfigurationApp;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Services;
using FundacionAMA.Infrastructure.Email;
using FundacionAMA.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FundacionAMA.Application.Extensions;

public static class AddSmtpConfigurationDependencyExtensions
{
    public static void AddSmtpConfigurationDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISmtpConfigurationRepository, SmtpConfigurationRepository>();
        services.AddScoped<ISmtpConfigurationService, SmtpConfigurationService>();
        services.AddScoped<ISmtpConfigurationAppService, SmtpConfigurationAppService>();
        services.AddScoped<ISMTPService, SMTPService>();

    }
}
