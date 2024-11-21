using DummyDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DummyDb.Infrastructure
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
    // Set DummyApi as Startup project, then open Package Manager Console and run the commands:
    // Add-Migration InitialMigration -Context CRMContext -Project DummyDb.DatabaseMigration
    // Update-Database -Context CRMContext -Project DummyDb.DatabaseMigration
}
