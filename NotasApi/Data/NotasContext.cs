using Microsoft.EntityFrameworkCore;
using NotasApi.Models;

namespace NotasApi.Data;

public class NotasContext : DbContext
{
    public NotasContext(DbContextOptions<NotasContext> options) : base(options) {}
    
    public DbSet<NotaFiscal> NotasFiscais { get; set; }
    public DbSet<NotaProduto> NotaProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotaFiscal>()
            .HasIndex(nf => nf.NumSequencial)
            .IsUnique();

        modelBuilder.Entity<NotaProduto>()
            .HasOne(np => np.Nota)
            .WithMany(n => n.Produtos)
            .HasForeignKey(np => np.NotaId);

        base.OnModelCreating(modelBuilder);
    }

}
