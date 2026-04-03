using ImpressaoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpressaoApi.Data;

public class ImpressaoContext : DbContext
{
    public ImpressaoContext(DbContextOptions<ImpressaoContext> options) : base(options) { }
    public DbSet<ImpressaoLog> ImpressaoLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImpressaoLog>()
            .Property(i => i.Status)
            .HasMaxLength(20);

        base.OnModelCreating(modelBuilder);
    }
}