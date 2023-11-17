﻿
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Repository
{
    public interface IUnitOfWork 
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        object CategoriasRepository { get; }

        void Commit();
    }
}
