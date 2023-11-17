using ApiCatalogoComRepository.Context;
using ApiCatalogoComRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoComRepository.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DbCatalogoContext context) : base(context)
        {

        }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }

    }
}
