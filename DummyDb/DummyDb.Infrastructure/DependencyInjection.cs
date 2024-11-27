using DummyDb.Application.IQueries;
using DummyDb.Infrastructure.ExternalServices;
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
            services.AddHttpClient();
            services.AddScoped<ISchoolClassQuery, SchoolClassQuery>();
            services.AddScoped<ICRMClusterQuery, CRMClusterQuery>();
            services.AddScoped<IFeedbackProxy, FeedbackProxy>();
            services.AddDbContext<CRMContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString
                    ("DefaultConnectionCRM"),
                    x => x.MigrationsAssembly("DummyDb.DatabaseMigration")));

            return services;
        }
    }
}
