using ApiCatalogoComRepository.Models;
using ApiCatalogoComRepository.Pagination;

namespace ApiCatalogoComRepository.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        PageList<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
        PageList<Categoria> GetCategoriasProdutos(CategoriasParameters categoriasParameters);
    }
}
