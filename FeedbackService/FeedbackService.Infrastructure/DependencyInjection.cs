using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Infrastructure.Queries;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FeedbackService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFeedbackpostQuery, FeedbackpostQuery>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedbackpostRepository, FeedbackpostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<FeedbackContext>>();


            services.AddDbContext<FeedbackContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString
                        ("FeedbackDb"),
                    x =>
                        x.MigrationsAssembly("FeedbackService.DatabaseMigration")));

            return services;
        }
    }
}
