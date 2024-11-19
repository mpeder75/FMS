using CRMSyncService.Application.IQueries;
using CRMSyncService.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRMSyncService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISchoolClassQuery, SchoolClassQuery>();

            // Add-Migration InitialMigration -Context CRMContext -Project CRMSyncService.DatabaseMigration
            // Update-Database -Context CRMContext -Project CRMSyncService.DatabaseMigration
            services.AddDbContext<CRMContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString
                    ("LocalConnectionCRM"),
                    x => x.MigrationsAssembly("CRMSyncService.DatabaseMigration")));

            return services;
        }

    }
}
