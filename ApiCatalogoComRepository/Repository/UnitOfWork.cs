using ApiCatalogoComRepository.Context;

namespace ApiCatalogoComRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository produtoRepository;
        private CategoriaRepository categoriaRepository;
        public DbCatalogoContext _context;

        public UnitOfWork(DbCatalogoContext context)
        {
            _context=context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get { return produtoRepository = produtoRepository ?? new ProdutoRepository(_context);}
        }

        public ICategoriaRepository CategoriaRepository
        {
            get { return categoriaRepository = categoriaRepository ?? new CategoriaRepository(_context);}
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
