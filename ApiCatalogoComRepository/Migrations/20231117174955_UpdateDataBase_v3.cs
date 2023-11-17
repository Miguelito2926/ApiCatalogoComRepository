using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogoComRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase_v3 : Migration
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
        { 16, "Smartphone", "Telefone inteligente",50f, "smartphone.jpg", 799.99, 1, DateTime.UtcNow.Date.Add(new TimeSpan(16, 0, 0)).ToString("2023-11-17 15:00:00")},
        { 17, "Laptop", "Computador portátil",70f, "laptop.jpg", 1299.99, 1, DateTime.UtcNow.Date.Add(new TimeSpan(16, 0, 0)).ToString("2023-11-17 15:00:00")},
        { 18, "Camiseta", "Camiseta casual",30f, "camiseta.jpg", 19.99, 2, DateTime.UtcNow.Date.Add(new TimeSpan(16, 0, 0)).ToString("2023-11-17 15:00:00")},
        { 19, "Calça Jeans", "Calça jeans moderna",60f, "calca-jeans.jpg", 39.99, 2, DateTime.UtcNow.Date.Add(new TimeSpan(16, 0, 0)).ToString("2023-11-17 15:00:00")},
        { 20, "Livro de Ficção", "Livro de ficção científica",10f, "livro-ficcao.jpg", 29.99, 3, DateTime.UtcNow.Date.Add(new TimeSpan(16, 0, 0)).ToString("2023-11-17 15:00:00")}

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

