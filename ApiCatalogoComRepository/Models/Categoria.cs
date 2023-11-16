using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogoComRepository.Models;

[Table("Categorias")]
public class Categoria
{
    [Key] // Defini a chave Primaria
    public int CategoriaId { get; set; }

    [Required] // Especifica que o valor do campo é obrigatório
    [MaxLength(80)]//Defini o tamanho mínimo ou máximo permitido para o tipo 
    public string? Nome { get; set; }

    [Required]
    [MaxLength(300)]
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; } = new Collection<Produto>();
}
