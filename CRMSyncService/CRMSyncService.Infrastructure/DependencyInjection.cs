using DummyDb.Application.IQueries;
using DummyDb.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DummyDb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISchoolClassQuery, SchoolClassQuery>();

            services.AddDbContext<CRMContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString
                    ("LocalConnectionCRM"),
                    x => x.MigrationsAssembly("DummyDb.DatabaseMigration")));

            return services;
        }

    }
}
