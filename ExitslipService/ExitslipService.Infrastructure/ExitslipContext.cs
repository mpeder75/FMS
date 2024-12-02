using ExitslipService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExitSlipService.Infrastructure;

public class ExitSlipContext : DbContext
{
    public DbSet<ExitSlip> ExitSlips { get; set; }

    public ExitSlipContext(DbContextOptions<ExitSlipContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
