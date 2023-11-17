using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;

namespace ApiCatalogoComRepository.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DbCatalogoContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Produto> GetProdutosPorPreco()
        {
            return Get().OrderBy(c => c.Preco).ToList();
        }
    }
}
