using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;
using Microsoft.AspNetCore.SignalR;

namespace ApiCatalogoComRepository.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DbCatalogoContext contexto) : base(contexto)
        {
        }

        public PageList<Produto> GetProdutos(ProdutosParameters produtosParameters)
        {
            //return Get()
              //  .OrderBy(on => on.Nome)
              //  .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
              //  .Take(produtosParameters.PageSize)
              //  .ToList();
              return PageList<Produto>.ToPageList(Get().OrderBy(on => on.Nome),
                  produtosParameters.PageNumber, produtosParameters.PageSize);
        }
        /* public IEnumerable<Produto> GetProdutosPorPreco() 
         {
             return Get().OrderBy(c => c.Preco).ToList();
         }*/

        public PageList<Produto> GetProdutosPorPreco(ProdutosParameters produtosParameters)
        {
            return PageList<Produto>.ToPageList(Get().OrderBy(on => on.Preco),
                produtosParameters.PageNumber,
                produtosParameters.PageSize);

        }
    }
}
