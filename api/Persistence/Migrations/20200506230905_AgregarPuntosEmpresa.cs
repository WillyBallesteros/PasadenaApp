using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgregarPuntosEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                  name: "TiposDeEmpresas",
                  schema: "loc",
                  columns: table => new
                  {
                      TipoEmpresaId = table.Column<int>(nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      TipoEmpresaNombre = table.Column<int>(maxLength: 80, nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_TipoEmpresa", x => x.TipoEmpresaId);
                  });

            migrationBuilder.CreateTable(
                name: "Empresas",
                schema: "loc",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaNombre = table.Column<int>(maxLength: 200, nullable: false),
                    Nit = table.Column<string>(maxLength: 30, nullable: true),
                    TipoEmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_TiposDeEmpresas_TipoEmpresaId",
                        column: x => x.TipoEmpresaId,
                        principalSchema: "loc",
                        principalTable: "TiposDeEmpresas",
                        principalColumn: "TipoEmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasPuntoVentas",
                columns: table => new
                {
                    EmpresasPuntoVentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    PuntoVentaId = table.Column<int>(nullable: false),
                    PuntoDeVentaPuntoVentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasPuntoVentas", x => x.EmpresasPuntoVentaId);
                    table.ForeignKey(
                        name: "FK_EmpresasPuntoVentas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "loc",
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresasPuntoVentas_PuntosDeVentas_PuntoDeVentaPuntoVentaId",
                        column: x => x.PuntoDeVentaPuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasPuntoVentas_EmpresaId",
                table: "EmpresasPuntoVentas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasPuntoVentas_PuntoDeVentaPuntoVentaId",
                table: "EmpresasPuntoVentas",
                column: "PuntoDeVentaPuntoVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TipoEmpresaId",
                schema: "loc",
                table: "Empresas",
                column: "TipoEmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresasPuntoVentas");

            migrationBuilder.DropTable(
                name: "Empresas",
                schema: "loc");

            migrationBuilder.DropTable(
                name: "TiposDeEmpresas",
                schema: "loc");
        }
    }
}
