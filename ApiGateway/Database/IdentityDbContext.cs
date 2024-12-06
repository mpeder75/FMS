using ApiGateway.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.Database;

public class IdentityDbContext : IdentityDbContext<AppUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.HasDefaultSchema("identity");
    }


    // Add-Migration InitialMigration -Context FeedbackContext -Project FeedbackService.DatabaseMigration
    // Update-Database -Context FeedbackContext -Project FeedbackService.DatabaseMigration
}