using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogoComRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Nome", "Descricao", "Estoque", "Imagem", "Preco", "CategoriaId", "DataCadastro" },
                values: new object[,]
                {
        // Produto 1-10
        { 6, "Smartphone", "Telefone inteligente",50f, "smartphone.jpg", 799.99, 1, DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))},
        { 7, "Laptop", "Computador portátil",70f, "laptop.jpg", 1299.99, 1, DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))},
        { 8, "Camiseta", "Camiseta casual",30f, "camiseta.jpg", 19.99, 2, DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))},
        { 9, "Calça Jeans", "Calça jeans moderna",60f, "calca-jeans.jpg", 39.99, 2, DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))},
        { 10, "Livro de Ficção", "Livro de ficção científica",10f, "livro-ficcao.jpg", 29.99, 3, DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))}

                    // Produto 11-20
                    // Adicione mais produtos conforme necessário

                    // Produto 21-30
                    // Adicione mais produtos conforme necessário
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
            table: "Produtos",
            keyColumn: "ProdutoId",
            keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            // Exclua mais produtos conforme necessário

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            // Exclua mais categorias conforme necessário
        }
    }
}
