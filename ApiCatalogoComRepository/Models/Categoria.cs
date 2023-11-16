using System.Collections.ObjectModel;

using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogoComRepository.Models;

[Table("Categorias")]
public class Categoria
{    public int CategoriaId { get; set; }
    public string? Nome { get; set; }   
    public string? Descricao { get; set; }
    public ICollection<Produto>? Produtos { get; set; } = new Collection<Produto>();
}
