using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class IdentityCoreInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cart");

            migrationBuilder.EnsureSchema(
                name: "loc");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, maxLength: 128),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 128, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                schema: "cart",
                columns: table => new
                {
                    GrupoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoNombre = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: true),
                    Orden = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                schema: "cart",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaNombre = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeAnuncios",
                schema: "cart",
                columns: table => new
                {
                    TipoAnuncioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnuncioNombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnuncio", x => x.TipoAnuncioId);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                schema: "loc",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoNombre = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, maxLength: 128)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false, maxLength: 128),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        principalSchema: "auth",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                schema: "loc",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoId = table.Column<int>(nullable: true),
                    CiudadNombre = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento",
                        column: x => x.DepartamentoId,
                        principalSchema: "loc",
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PuntosDeVentas",
                schema: "loc",
                columns: table => new
                {
                    PuntoVentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true),
                    Celular = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Web = table.Column<string>(maxLength: 128, nullable: true),
                    Contacto = table.Column<string>(maxLength: 100, nullable: true),
                    CiudadId = table.Column<int>(nullable: true),
                    Logo = table.Column<string>(maxLength: 150, nullable: true),
                    Lat = table.Column<string>(maxLength: 50, nullable: true),
                    Lon = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoVenta", x => x.PuntoVentaId);
                    table.ForeignKey(
                        name: "FK_PuntoVenta_Ciudad",
                        column: x => x.CiudadId,
                        principalSchema: "loc",
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    UserName = table.Column<string>(maxLength: 128, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 128, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 128, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NumeroCedula = table.Column<string>(maxLength: 20, nullable: true),
                    Nombres = table.Column<string>(maxLength: 100, nullable: true),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    CiudadId = table.Column<int>(nullable: true),
                    PuntoVentaId = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Ciudad",
                        column: x => x.CiudadId,
                        principalSchema: "loc",
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_PuntoVenta",
                        column: x => x.PuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "cart",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plu = table.Column<string>(maxLength: 20, nullable: true),
                    ProductoNombre = table.Column<string>(maxLength: 100, nullable: true),
                    MarcaId = table.Column<int>(nullable: true),
                    GrupoId = table.Column<int>(nullable: true),
                    PuntoVentaId = table.Column<int>(nullable: true),
                    ImagenNombre = table.Column<string>(maxLength: 50, nullable: true),
                    ImagenData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Grupo",
                        column: x => x.GrupoId,
                        principalSchema: "cart",
                        principalTable: "Grupos",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Marca",
                        column: x => x.MarcaId,
                        principalSchema: "cart",
                        principalTable: "Marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_PuntoVenta",
                        column: x => x.PuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false, maxLength: 128),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false, maxLength: 128),
                    ProviderKey = table.Column<string>(nullable: false, maxLength: 128),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false, maxLength: 128)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false, maxLength: 128),
                    RoleId = table.Column<string>(nullable: false, maxLength: 128)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false, maxLength: 128),
                    LoginProvider = table.Column<string>(nullable: false, maxLength: 128),
                    Name = table.Column<string>(nullable: false, maxLength: 128),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anuncios",
                schema: "cart",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<string>(maxLength: 10, nullable: true),
                    TipoAnuncioId = table.Column<int>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 1000, nullable: true),
                    ProductoId = table.Column<int>(nullable: true),
                    PuntoVentaId = table.Column<int>(nullable: true),
                    FechaInicio = table.Column<string>(maxLength: 10, nullable: true),
                    FechaFin = table.Column<string>(maxLength: 10, nullable: true),
                    ValorAnterior = table.Column<int>(nullable: true),
                    ValorActual = table.Column<int>(nullable: true),
                    PorcentajeDcto = table.Column<int>(nullable: true),
                    ImagenNombre = table.Column<string>(maxLength: 50, nullable: true),
                    ImagenData = table.Column<byte[]>(nullable: true),
                    Destacado = table.Column<int>(nullable: true),
                    DestacadoId = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: true),
                    Orden = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.AnuncioId);
                    table.ForeignKey(
                        name: "FK_Anuncio_Producto",
                        column: x => x.ProductoId,
                        principalSchema: "cart",
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncio_PuntoVenta",
                        column: x => x.PuntoVentaId,
                        principalSchema: "loc",
                        principalTable: "PuntosDeVentas",
                        principalColumn: "PuntoVentaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncio_TipoAnuncio",
                        column: x => x.TipoAnuncioId,
                        principalSchema: "cart",
                        principalTable: "TiposDeAnuncios",
                        principalColumn: "TipoAnuncioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                schema: "auth",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                schema: "auth",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "auth",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "auth",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "auth",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CiudadId",
                schema: "auth",
                table: "AspNetUsers",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "auth",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PuntoVentaId",
                schema: "auth",
                table: "AspNetUsers",
                column: "PuntoVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_ProductoId",
                schema: "cart",
                table: "Anuncios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_PuntoVentaId",
                schema: "cart",
                table: "Anuncios",
                column: "PuntoVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_TipoAnuncioId",
                schema: "cart",
                table: "Anuncios",
                column: "TipoAnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_GrupoId",
                schema: "cart",
                table: "Productos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                schema: "cart",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PuntoVentaId",
                schema: "cart",
                table: "Productos",
                column: "PuntoVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                schema: "loc",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntosDeVentas_CiudadId",
                schema: "loc",
                table: "PuntosDeVentas",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "UQ__PuntosDe__C7D1D6DA0CBAE877",
                schema: "loc",
                table: "PuntosDeVentas",
                column: "Nit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Anuncios",
                schema: "cart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "cart");

            migrationBuilder.DropTable(
                name: "TiposDeAnuncios",
                schema: "cart");

            migrationBuilder.DropTable(
                name: "Grupos",
                schema: "cart");

            migrationBuilder.DropTable(
                name: "Marcas",
                schema: "cart");

            migrationBuilder.DropTable(
                name: "PuntosDeVentas",
                schema: "loc");

            migrationBuilder.DropTable(
                name: "Ciudades",
                schema: "loc");

            migrationBuilder.DropTable(
                name: "Departamentos",
                schema: "loc");
        }
    }
}
