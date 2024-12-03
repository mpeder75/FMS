using ExitslipService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExitSlipService.Infrastructure;

public class ExitSlipContext(DbContextOptions<ExitSlipContext> options) : DbContext(options)
{
    public DbSet<ExitSlipReply> ExitSlipReplies { get; set; }

    public DbSet<ExitSlipPost> ExitSlipPosts { get; set; }

}
