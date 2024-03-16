using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.MVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) VALUES ('Caderno Espiral', 'Caderno Espiral 100 folhas', 7.45,50,'Caderno1.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) VALUES ('Estojo escolar', 'Estojo escolar cinza', 5.45,50,'Estojo.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) VALUES ('Lapis', 'Lapiz vermelho', 1.45,50,'Lapiz.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) VALUES ('Calculadora', 'Calculadora eletronica', 10.45,50,'Calculadora.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM products");
        }
    }
}
