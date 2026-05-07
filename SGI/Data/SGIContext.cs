using Microsoft.EntityFrameworkCore;
using SGI.Models;

namespace SGI.Data;

public class SGIContext : DbContext
{
    public SGIContext(DbContextOptions<SGIContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("produtos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(p => p.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(p => p.Preco)
                  .HasColumnName("preco")
                  .HasColumnType("decimal(10,2)")
                  .IsRequired();

            entity.Property(p => p.Quantidade)
                  .HasColumnName("quantidade")
                  .HasDefaultValue(0)
                  .IsRequired();
        });
    }
}
