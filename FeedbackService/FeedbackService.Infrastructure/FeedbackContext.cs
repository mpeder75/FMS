using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure;

public class FeedbackContext : DbContext
{
    public DbSet<FeedbackPost> FeedbackPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    // Add-Migration InitialMigration -Context FeedbackContext -Project FeedbackService.DatabaseMigration
    // Update-Database -Context FeedbackContext -Project FeedbackService.DatabaseMigration
}

