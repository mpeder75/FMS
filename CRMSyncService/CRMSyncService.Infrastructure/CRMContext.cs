using Microsoft.EntityFrameworkCore;
using SharedKernel.Entities;


namespace CRMSyncService.Infrastructure
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        { }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
