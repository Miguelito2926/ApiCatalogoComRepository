namespace ApiCatalogoComRepository.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
