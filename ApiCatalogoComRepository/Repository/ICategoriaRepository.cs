using ApiCatalogoComRepository.Models;

namespace ApiCatalogoComRepository.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
