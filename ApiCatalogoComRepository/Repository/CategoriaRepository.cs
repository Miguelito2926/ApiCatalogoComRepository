using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DbCatalogoContext context) : base(context)
        {

        }

        public PageList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
        {
            return PageList<Categoria>.ToPageList(Get().OrderBy(on => on.Nome),
                categoriasParameters.PageNumber,
                categoriasParameters.PageSize);
        }
        public PageList<Categoria> GetCategoriasProdutos(CategoriasParameters categoriasParameters)
        {
            return PageList<Categoria>.ToPageList(Get().Include(x => x.Produtos),
                categoriasParameters.PageNumber,
                categoriasParameters.PageSize);
                
        }

    }
}
