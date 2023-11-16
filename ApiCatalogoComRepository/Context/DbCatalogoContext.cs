using ApiCatalogoComRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Context;

public class DbCatalogoContext : DbContext
{
    public DbCatalogoContext (DbContextOptions<DbCatalogoContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

}
