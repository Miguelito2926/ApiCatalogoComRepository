﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogoComRepository.Models;
[Table("Produtos")]
public class Produto
{
    public int ProdutoId { get; set; }   
    public string? Nome { get; set; }   
    public string? Descricao{ get; set; }   
    public decimal Preco { get; set; }   
    public string? Imagem { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
