using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddProductFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                schema: "cart",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Presentacion",
                schema: "cart",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                schema: "cart",
                table: "Productos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAnterior",
                schema: "cart",
                table: "Productos",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                schema: "cart",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Presentacion",
                schema: "cart",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Valor",
                schema: "cart",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ValorAnterior",
                schema: "cart",
                table: "Productos");
        }
    }
}
