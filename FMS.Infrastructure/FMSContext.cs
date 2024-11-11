using FMS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Infrastructure
{
    public class FMSContext : DbContext
    {
        public FMSContext(DbContextOptions<FMSContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }
}
