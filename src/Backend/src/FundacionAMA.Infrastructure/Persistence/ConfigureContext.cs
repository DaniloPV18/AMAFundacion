using FundacionAMA.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FundacionAMA.Infrastructure.Persistence;

public static class ConfigureContextExtensions
{
    public static void AddSqlServerContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AMADbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(AMADbContext).Assembly.GetName().Name);
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

            options.EnableSensitiveDataLogging();
            options.EnableServiceProviderCaching(true);
            options.EnableThreadSafetyChecks();
            options.EnableDetailedErrors();
        }, ServiceLifetime.Scoped);
    }

    public static void AddMariaDBContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AMADbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                              mySqlOptionsAction: sqlOptions =>
                              {
                                  sqlOptions.EnableIndexOptimizedBooleanColumns(true);
                                  sqlOptions.EnableRetryOnFailure(
                                  maxRetryCount: 5,
                                  maxRetryDelay: TimeSpan.FromSeconds(30),
                                  errorNumbersToAdd: null);
                                  sqlOptions.EnableIndexOptimizedBooleanColumns();
                                  sqlOptions.MigrationsAssembly(typeof(AMADbContext).Assembly.GetName().Name);

                              });
            options.EnableSensitiveDataLogging();
            options.EnableServiceProviderCaching(true);
            options.EnableThreadSafetyChecks();
            options.EnableDetailedErrors();
        }, ServiceLifetime.Scoped);
    }
}