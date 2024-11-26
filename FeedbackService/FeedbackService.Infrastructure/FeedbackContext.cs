using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure;

public class FeedbackContext : DbContext
{
    public DbSet<Feedbackpost> Feedbackposts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SchoolClass> SchoolClasses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
    {
    }
}

