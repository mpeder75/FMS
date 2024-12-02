using ExitslipService.Application.Interfaces;
using ExitslipService.Application.Query;
using ExitslipService.Application.UnitOfWork;
using ExitSlipService.Infrastructure.OnionDemo.Infrastructure;
using ExitSlipService.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExitSlipService.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExitSlipQuery, ExitSlipQuery>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ExitSlipContext>>();
            services.AddScoped<IExitSlipRepository, ExitSlipRepository>();

            // Database
            // https://github.com/dotnet/SqlClient/issues/2239
            // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
            // Add-Migration InitialMigration -Context ExitSlipContext -Project ExitslipService.DatabaseMigration
            // Update-Database -Context ExitSlipContext -Project ExitslipService.DatabaseMigration
            services.AddDbContext<ExitSlipContext>(options => options
                    .UseSqlServer(configuration
                    .GetConnectionString("ExitSlipDbConnection"),
                    x => x.MigrationsAssembly("ExitslipService.DatabaseMigration")));
            
            return services;
        }
    }
}
