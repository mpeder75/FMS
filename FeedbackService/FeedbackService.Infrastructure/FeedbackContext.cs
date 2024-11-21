using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure;

internal class FeedbackContext : DbContext
{
    public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
    {
    }

    public DbSet<Feedbackpost> Feedbackposts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<SchoolClass> SchoolClasses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}