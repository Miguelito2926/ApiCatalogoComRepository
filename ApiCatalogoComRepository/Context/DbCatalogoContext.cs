using ApiCatalogoComRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Context;

public class DbCatalogoContext : DbContext
{
    public DbCatalogoContext (DbContextOptions<DbCatalogoContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    // Método chamado durante a criação do modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração das propriedades da entidade Categoria
        modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaId);
        modelBuilder.Entity<Categoria>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Categoria>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();

        // Configuração das propriedades da entidade Produto
        modelBuilder.Entity<Produto>().HasKey(c => c.ProdutoId);
        modelBuilder.Entity<Produto>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Produto>().Property(c => c.Descricao).HasMaxLength(150);
        modelBuilder.Entity<Produto>().Property(c => c.Imagem).HasMaxLength(100);
        modelBuilder.Entity<Produto>().Property(c => c.Preco).HasPrecision(14, 2);

        // Definição do relacionamento um-para-muitos entre Produto e Categoria
        modelBuilder.Entity<Produto>().HasOne(c => c.Categoria)
            .WithMany(p => p.Produtos)
            .HasForeignKey(c => c.CategoriaId);
    }
}
