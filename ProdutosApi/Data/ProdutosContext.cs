namespace ProdutosApi.Data;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.Models;

public class ProdutosContext : DbContext
{
    public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options)
    {}
    public DbSet<Produto> Produtos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasIndex(p => p.Codigo)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
