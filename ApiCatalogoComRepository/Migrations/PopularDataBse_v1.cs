using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogoComRepository.Migrations;

public class PopularDataBse_v1 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Categorias",
            columns: new[] { "CategoriaId", "Nome", "Descricao" },
            values: new object[,]
            {
        { 1, "Eletrônicos", "Categoria de produtos eletrônicos" },
        { 2, "Roupas", "Categoria de produtos de vestuário" },
        { 3, "Livros", "Categoria de livros" }
                // Adicione mais categorias conforme necessário
            });

        migrationBuilder.InsertData(
            table: "Produtos",
            columns: new[] { "ProdutoId", "Nome", "Descricao", "Imagem", "Preco", "CategoriaId" },
            values: new object[,]
            {
        // Produto 1-10
        { 1, "Smartphone", "Telefone inteligente", "smartphone.jpg", 799.99, 1 },
        { 2, "Laptop", "Computador portátil", "laptop.jpg", 1299.99, 1 },
        { 3, "Camiseta", "Camiseta casual", "camiseta.jpg", 19.99, 2 },
        { 4, "Calça Jeans", "Calça jeans moderna", "calca-jeans.jpg", 39.99, 2 },
        { 5, "Livro de Ficção", "Livro de ficção científica", "livro-ficcao.jpg", 29.99, 3 },

                // Produto 11-20
                // Adicione mais produtos conforme necessário

                // Produto 21-30
                // Adicione mais produtos conforme necessário
            });
    }

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
