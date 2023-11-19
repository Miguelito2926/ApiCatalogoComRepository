using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;

namespace ApiCatalogoComRepository.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParameters);
        IEnumerable<Produto> GetProdutosPorPreco();
        
    }
}
