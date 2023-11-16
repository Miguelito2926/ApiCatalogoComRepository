using ApiCatalogoComRepository.Models;

namespace ApiCatalogoComRepository.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
