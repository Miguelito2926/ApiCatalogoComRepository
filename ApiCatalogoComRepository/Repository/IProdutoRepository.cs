﻿using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;

namespace ApiCatalogoComRepository.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        PageList<Produto> GetProdutos(ProdutosParameters produtosParameters);
        IEnumerable<Produto> GetProdutosPorPreco();
        
    }
}
