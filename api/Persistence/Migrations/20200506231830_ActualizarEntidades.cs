using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ActualizarEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasPuntosVentas",
                schema: "loc",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false),
                    PuntoVentaId = table.Column<int>(nullable: false),
                    EmpresasPuntoVentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasPuntosVentas", x => new { x.EmpresaId, x.PuntoVentaId });
                    table.ForeignKey(
                        name: "FK_EmpresasPuntosVentas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "loc",
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasPuntosVentas_PuntosDeVentas_PuntoVentaId",
                        column: x => x.PuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasPuntosVentas_PuntoVentaId",
                schema: "loc",
                table: "EmpresasPuntosVentas",
                column: "PuntoVentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasPuntoVentas",
                schema: "loc",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PuntoVentaId = table.Column<int>(type: "int", nullable: false),
                    EmpresasPuntoVentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasPuntoVentas", x => new { x.EmpresaId, x.PuntoVentaId });
                    table.ForeignKey(
                        name: "FK_EmpresasPuntoVentas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "loc",
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasPuntoVentas_PuntosDeVentas_PuntoVentaId",
                        column: x => x.PuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasPuntoVentas_PuntoVentaId",
                schema: "loc",
                table: "EmpresasPuntoVentas",
                column: "PuntoVentaId");
        }
    }
}
