using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TipoDocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                schema: "auth",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposDeDocumentos",
                schema: "auth",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumentoNombre = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipoDocumentoId",
                schema: "auth",
                table: "AspNetUsers",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoDocumento",
                schema: "auth",
                table: "AspNetUsers",
                column: "TipoDocumentoId",
                principalSchema: "auth",
                principalTable: "TiposDeDocumentos",
                principalColumn: "TipoDocumentoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoDocumento",
                schema: "auth",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TiposDeDocumentos",
                schema: "auth");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TipoDocumentoId",
                schema: "auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                schema: "auth",
                table: "AspNetUsers");
        }
    }
}
